using Microsoft.AspNetCore.Identity;
using SQLicious.Server.Model.DTOs.Admin;
using SQLicious.Server.Model;
using SQLicious.Server.Options;
using System.Security.Claims;

namespace SQLicious.Server.Services.IServices
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAdmins();
        Task<Admin> GetAdminById(int id);
        Task<AccountCreationResult> CreateAdminAsync(CreateAccountRequestDTO request);
        Task<IdentityResult> UpdateAdminAsync(Admin admin);
        Task<IdentityResult> DeleteAdminAsync(string password, ClaimsPrincipal currentUser);
        Task<LoginResult> LoginAsync(string email, string password);
        Task<IdentityResult> SendEmailVerificationAsync(string userId, string code);
    }
}
