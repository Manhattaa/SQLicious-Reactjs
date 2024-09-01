using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Model;

namespace SQLicious.Server.Data.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantContext _context;

        public TableRepository(RestaurantContext context)
        {
            _context = context;
        }
        public async Task CreateTableAsync(Table table)
        {
            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            return await _context.Tables.FindAsync(tableId);
        }

        public async Task UpdateTableAsync(Table table)
        {
            throw new NotImplementedException();
        }
    }
}
