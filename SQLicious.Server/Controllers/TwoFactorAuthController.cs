using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using SQLicious.Server.Model;
using SQLicious.Server.Services;

namespace SQLicious.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwoFactorAuthController : ControllerBase
    {

        private readonly UserManager<Admin> _userManager;
        private readonly AuthenticationService _authService;
        private readonly AdminService _adminService;

        public TwoFactorAuthController(UserManager<Admin> userManager, AuthenticationService authService, AdminService adminService)
        {
            _userManager = userManager;
            _authService = authService;
            _adminService = adminService;
        }

        //[HttpGet]
        //public async Task<IActionResult> TwoFactor
        //[HttpPost("enable-2fa")]
        //public async Task<IActionResult> EnableTwoFactorAuthentication()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return BadRequest("User not found.");
        //    }

        //    // Check if the user already has 2FA enabled
        //    if (user.TwoFactorEnabled)
        //    {
        //        return BadRequest("Two-Factor Authentication is already enabled.");
        //    }

        //    // Generate the authenticator key
        //    var authenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user);
        //    if (string.IsNullOrEmpty(authenticatorKey))
        //    {
        //        await _userManager.ResetAuthenticatorKeyAsync(user);
        //        authenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user);
        //    }

        //    // Generate a QR code URI
        //    var qrCodeUri = GenerateQrCodeUri(user.Email, authenticatorKey);

        //    return Ok(new { AuthenticatorKey = authenticatorKey, QrCodeUri = qrCodeUri });
        //}

        //private string GenerateQrCodeUri(string email, string authenticatorKey)
        //{
        //    var qrCodeGenerator = new QrCodeGenerator();
        //    var encodedKey = Uri.EscapeDataString(authenticatorKey);
        //    var encodedEmail = Uri.EscapeDataString(email);
        //    var uri = $"otpauth://totp/{encodedEmail}?secret={encodedKey}&issuer=SQLicious";

        //    return uri;
        //}

        //[HttpPost("verify-2fa")]
        //public async Task<IActionResult> VerifyTwoFactorAuthentication([FromForm] string verificationCode)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return BadRequest("User not found.");
        //    }

        //    // Verify the token
        //    var result = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultAuthenticatorProvider, verificationCode);
        //    if (!result)
        //    {
        //        return BadRequest("Invalid verification code.");
        //    }

        //    // Enable 2FA for the user
        //    await _userManager.SetTwoFactorEnabledAsync(user, true);

        //    return Ok("Two-Factor Authentication enabled successfully.");
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> LoginAdmin([FromForm] string email, [FromForm] string password, [FromForm] string? verificationCode = null)
        //{
        //    var result = await _adminService.LoginAsync(email, password);
        //    if (!result.Success)
        //    {
        //        return Unauthorized(result.ErrorMessage);
        //    }

        //    // Check if Two-Factor Authentication is enabled
        //    var user = await _userManager.FindByEmailAsync(email);
        //    if (user.TwoFactorEnabled && string.IsNullOrEmpty(verificationCode))
        //    {
        //        return Ok(new { RequiresTwoFactor = true, Message = "Two-Factor Authentication is required." });
        //    }

        //    if (user.TwoFactorEnabled)
        //    {
        //        var tokenValid = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultAuthenticatorProvider, verificationCode);
        //        if (!tokenValid)
        //        {
        //            return Unauthorized("Invalid two-factor authentication code.");
        //        }
        //    }

        //    // Generate JWT token
        //    var token = _authService.GenerateToken(user);
        //    return Ok(new { Message = "Login successful", Token = token });
        //}

    }
}
