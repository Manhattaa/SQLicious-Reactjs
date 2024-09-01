namespace SQLicious.Server.Data.Repository.IRepositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<IAdminRepository>> GetAllAdmins();
    }
}
