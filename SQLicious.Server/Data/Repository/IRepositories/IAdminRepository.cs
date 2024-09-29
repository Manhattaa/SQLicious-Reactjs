using Microsoft.AspNetCore.Identity;
using SQLicious.Server.Model;
using SQLicious.Server.Options;
using System.Security.Claims;

namespace SQLicious.Server.Data.Repository.IRepositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<Admin> GetAdminById(int id);
        Task<IdentityResult> CreateAdminAsync(Admin admin, string password);
        Task<IdentityResult> UpdateAdminAsync(Admin admin);
        Task<IdentityResult> DeleteAdminAsync(string password, ClaimsPrincipal currentUser);
        Task<LoginResult> LoginAsync(string email, string password);
        Task<IdentityResult> SendEmailVerificationAsync(string userId, string code);
        Task<Admin> GetAdminByEmailAsync(string email);
    }
}
