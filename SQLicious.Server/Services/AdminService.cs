using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Services.IServices;

namespace SQLicious.Server.Services
{
    public class AdminService : IAdminService
    {
        public Task<IEnumerable<IAdminRepository>> GetAllAdmins()
        {
            throw new NotImplementedException();
        }
    }
}
