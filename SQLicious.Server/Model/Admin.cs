using Microsoft.AspNetCore.Identity;
namespace SQLicious.Server.Model
{
    public class Admin : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? AuthenticatorKey { get; set; }
    }
}
