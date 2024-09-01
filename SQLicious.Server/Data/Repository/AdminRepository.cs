using SQLicious.Server.Data.Repository.IRepositories;

namespace SQLicious.Server.Data.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public Task<IEnumerable<IAdminRepository>> GetAllAdmins()
        {
            throw new NotImplementedException();
        }
    }
}
