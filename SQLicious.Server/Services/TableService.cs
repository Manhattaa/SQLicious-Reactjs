using SQLicious.Server.Model;
using SQLicious.Server.Services.IServices;

namespace SQLicious.Server.Services
{
    public class TableService : ITableService
    {
        public Task CreateTableAsync(Table table)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTableAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Table>> GetListAllFreeTablesDateTime(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task<Table> GetTableByIdAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTableAsync(Table table)
        {
            throw new NotImplementedException();
        }
    }
}
