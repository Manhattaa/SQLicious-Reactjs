using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLicious.Server.Model.DTOs.Admin;
using SQLicious.Server.Model;
using SQLicious.Server.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace SQLicious.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly UserManager<Admin> _userManager;
        private readonly SignInManager<Admin> _signInManager;

        public AdminController(IAdminService adminService, UserManager<Admin> userManager)
        {
            _adminService = adminService;
            _userManager = userManager;
        }

        // GET: api/Admin/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAdmins();
            return Ok(admins.Select(a => new { a.Id, a.Email }));
        }

        // GET: api/Admin/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _adminService.GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        // POST: api/Admin/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAccountRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _adminService.CreateAdminAsync(request);

            if (result.Success)
            {
                // Return the JWT token with the success message
                return Ok(new { Message = "Admin created successfully", Token = result.Token });
            }

            return BadRequest(new { Message = result.Errors });
        }



        // PUT: api/Admin/edit
        [HttpPut("edit")]
        public async Task<IActionResult> EditAdmin([FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _adminService.UpdateAdminAsync(admin);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Admin updated successfully" });
            }

            return BadRequest(result.Errors);
        }

        // DELETE: api/Admin/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAdmin(int id, [FromBody] DeleteAdminRequestModel model)
        {
            var result = await _adminService.DeleteAdminAsync(model.Password, User);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Admin deleted successfully" });
            }

            return BadRequest(result.Errors);
        }

        // POST: api/Admin/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAdmin([FromForm]string email, [FromForm] string password)
        {
            var result = await _adminService.LoginAsync(email, password);
            if (result.Success)
            {
                return Ok(new { Message = "Login successful", Token = result.Token });
            }
            else
            {
                return Unauthorized(result.ErrorMessage);
            }
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequestDTO model)
        {
            var result = await _adminService.SendEmailVerificationAsync(model.UserId, model.Code);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Email confirmed successfully" });
            }

            return BadRequest(new { Message = "Email verification failed" });
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (result.Succeeded)
            {
                return Ok("Password changed successfully.");
            }

            return BadRequest("Password change failed.");
        }
    }
}