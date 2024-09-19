using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs.Table;

namespace SQLicious.Server.Data.Repository.IRepositories
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> GetAllTablesAsync();
        Task<Table> GetTableByIdAsync(int tableId);
        Task CreateTableAsync(Table table);
        Task<IEnumerable<Table>> GetListAllFreeTablesDateTime(DateTime dateTime);
        Task UpdateTableAsync(int tableId, UpdateTableDTO table);
        Task DeleteTableAsync(int tableId);
    }
}
