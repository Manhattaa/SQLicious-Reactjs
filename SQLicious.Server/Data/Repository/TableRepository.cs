using Microsoft.EntityFrameworkCore;
using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs.Table;

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
            var table = await _context.Tables.FindAsync(tableId);

            if (table != null)
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Table>> GetListAllFreeTablesDateTime(DateTime dateTime)
        {
            var tables = await _context.Bookings
                .Where(d => d.BookedDateTime != dateTime)
                .Select(t => t.Table)
                .ToListAsync();
            return tables;
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            var listTables = await _context.Tables.ToListAsync();
            return listTables;
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            return await _context.Tables.FindAsync(tableId);
        }

        public async Task UpdateTableAsync(int tableId, UpdateTableDTO tableDto)
        {
           
            var table = await _context.Tables.FindAsync(tableId);

            if (table != null)
            {
                table.IsAvailable = tableDto.IsAvailable;

                _context.Tables.Update(table);
                await _context.SaveChangesAsync();
            }
        }
    }
}
