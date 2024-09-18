using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs.Table;

namespace SQLicious.Server.Services.IServices
{
    public interface ITableService
    {
        Task<IEnumerable<TableDTO>> GetAllTablesAsync();
        Task<TableDTO> GetTableByIdAsync(int tableId);
        Task CreateTableAsync(TableCreationDTO table);
        Task<IEnumerable<TableDTO>> GetListAllFreeTablesDateTime(DateTime dateTime);
        Task UpdateTableAsync(TableDTO table);
        Task DeleteTableAsync(int tableId);
    }
}
