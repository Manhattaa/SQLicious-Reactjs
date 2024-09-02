using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs;
using SQLicious.Server.Services.IServices;

namespace SQLicious.Server.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }
        public async Task CreateTableAsync(TableCreationDTO table)
        {
            try
            {
                var newTable = new Table { Capacity = table.Capacity };

                await _tableRepository.CreateTableAsync(newTable);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to create the Table: {ex.Message}");
            }
        }

        public async Task DeleteTableAsync(int tableId)
        {
            try
            {
                await _tableRepository.DeleteTableAsync(tableId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to delete the Table: {ex.Message}");
            }
        }

        public async Task<IEnumerable<TableDTO>> GetAllTablesAsync()
        {
            try
            {
                var listOfTables = await _tableRepository.GetAllTablesAsync();

                return listOfTables.Select(t => new TableDTO
                {
                    TableId = t.TableId,
                    SeatingCapacity = t.Capacity
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<TableDTO>> GetListAllFreeTablesDateTime(DateTime dateTime)
        {
            try
            {
                var listOfAvailableTables = await _tableRepository.GetListAllFreeTablesDateTime(dateTime);

                return listOfAvailableTables.Select(t => new TableDTO
                {
                    TableId = t.TableId,
                    SeatingCapacity = t.Capacity
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<TableDTO> GetTableByIdAsync(int tableId)
        {
            try
            {
                var table = await _tableRepository.GetTableByIdAsync(tableId);

                if (table == null) { return null; }

                return new TableDTO
                {
                    TableId = table.TableId,
                    SeatingCapacity = table.Capacity
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task UpdateTableAsync(TableDTO table)
        {
            try
            {
                if (table != null)
                {
                    var updatedTable = new Table
                    {
                        TableId = table.TableId,
                        Capacity = table.SeatingCapacity,
                    };

                    await _tableRepository.UpdateTableAsync(updatedTable);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to update the Table: {ex.Message}");
            }
        }
    }
}
