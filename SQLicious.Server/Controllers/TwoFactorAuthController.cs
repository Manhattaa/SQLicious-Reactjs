﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using SQLicious.Server.Helpers;
using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs;
using System.IO;
using System.Threading.Tasks;

namespace SQLicious.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwoFactorAuthController : ControllerBase
    {
        private readonly UserManager<Admin> _userManager;
        private readonly SignInManager<Admin> _signInManager;

        public TwoFactorAuthController(UserManager<Admin> userManager, SignInManager<Admin> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Enable 2FA for the current admin
        [HttpPost("enable-2fa")]
        public async Task<IActionResult> EnableTwoFactorAuthentication([FromBody] TwoFactorAuthDTO code)
        {
            var admin = await _userManager.GetUserAsync(User);
            if (admin == null)
            {
                return NotFound("Admin not found");
            }

            var isTwoFactorEnabled = await _userManager.GetTwoFactorEnabledAsync(admin);
            if (isTwoFactorEnabled)
            {
                return BadRequest("Two-factor authentication is already enabled.");
            }

            if (string.IsNullOrEmpty(admin.AuthenticatorKey))
            {
                // Generate a new authenticator key
                await _userManager.ResetAuthenticatorKeyAsync(admin);
                var unformattedKey = await _userManager.GetAuthenticatorKeyAsync(admin);

                // Hash the key using the helper class
                admin.AuthenticatorKey = AuthenticatorHelper.HashAuthenticatorKey(unformattedKey);

                // Save the hashed key in the database
                var result = await _userManager.UpdateAsync(admin);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error storing authenticator key.");
                }
            }

            // Verify the 6-digit code entered by the admin
            var isValidCode = await _userManager.VerifyTwoFactorTokenAsync(admin, TokenOptions.DefaultAuthenticatorProvider, code.Code);

            if (!isValidCode)
            {
                return BadRequest("Invalid 2FA code.");
            }

            // Enable 2FA for this admin
            await _userManager.SetTwoFactorEnabledAsync(admin, true);

            return Ok(new { Message = "Two-factor authentication enabled successfully." });
        }

        // Generate QR code for 2FA setup
        [HttpGet("generate-qr-code")]
        public async Task<IActionResult> GenerateQrCode()
        {
            var admin = await _userManager.GetUserAsync(User);
            if (admin == null)
            {
                Console.WriteLine("Admin not found.");
                return BadRequest("Admin not found");
            }

            var unformattedKey = await _userManager.GetAuthenticatorKeyAsync(admin);
            if (string.IsNullOrEmpty(unformattedKey))
            {
                await _userManager.ResetAuthenticatorKeyAsync(admin);
                unformattedKey = await _userManager.GetAuthenticatorKeyAsync(admin);
            }

            var email = admin.Email;
            var authenticatorUri = GenerateQrCodeUri(email, unformattedKey);

            using (var qrGenerator = new QRCodeGenerator())
            using (var qrCodeData = qrGenerator.CreateQrCode(authenticatorUri, QRCodeGenerator.ECCLevel.Q))
            using (var qrCode = new PngByteQRCode(qrCodeData))
            {
                var qrCodeBytes = qrCode.GetGraphic(20);
                return File(qrCodeBytes, "image/png");
            }
        }

        // Verify 2FA token
        [HttpPost("verify-2fa")]
        public async Task<IActionResult> VerifyTwoFactorCode([FromBody] TwoFactorAuthDTO code)
        {
            var admin = await _userManager.GetUserAsync(User);
            if (admin == null)
            {
                return NotFound("Admin not found");
            }

            // Get the stored hashed authenticator key
            var hashedKey = admin.AuthenticatorKey;

            // Check the code using the hashed key
            var isValidCode = await _userManager.VerifyTwoFactorTokenAsync(admin, TokenOptions.DefaultAuthenticatorProvider, code.Code);

            if (!isValidCode)
            {
                return BadRequest("Invalid 2FA code.");
            }

            // Enable 2FA for this admin
            await _userManager.SetTwoFactorEnabledAsync(admin, true);

            return Ok("2FA setup verified successfully.");
        }

        // Disable 2FA
        [HttpPost("disable-2fa")]
        public async Task<IActionResult> DisableTwoFactorAuthentication()
        {
            var admin = await _userManager.GetUserAsync(User);
            if (admin == null)
            {
                return NotFound("Admin not found");
            }

            var disable2FaResult = await _userManager.SetTwoFactorEnabledAsync(admin, false);
            if (!disable2FaResult.Succeeded)
            {
                return BadRequest("Failed to disable two-factor authentication.");
            }

            return Ok("Two-factor authentication has been disabled.");
        }

        private string GenerateQrCodeUri(string email, string unformattedKey)
        {
            return string.Format(
                "otpauth://totp/{0}?secret={1}&issuer=SQLicious&digits=6",
                email, unformattedKey);
        }
    }
}
