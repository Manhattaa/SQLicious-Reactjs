using SQLicious.Server.Data.Repository.IRepositories;

namespace SQLicious.Server.Services.IServices
{
    public interface IAdminService
    {
        Task<IEnumerable<IAdminRepository>> GetAllAdmins();
    }
}
