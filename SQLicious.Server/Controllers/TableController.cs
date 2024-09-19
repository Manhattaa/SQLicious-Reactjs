using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLicious.Server.Data;
using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs.Table;

namespace SQLicious.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public TableController(RestaurantContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            return await _context.Tables.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }

            return table;
        }

        [HttpPost]
        public async Task<ActionResult<Table>> PostTable(TableCreationDTO tableDto)
        {
            // Map the DTO to the Table entity
            var newTable = new Table
            {
                Capacity = tableDto.Capacity,
                IsAvailable = tableDto.IsAvailable
            };

            _context.Tables.Add(newTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTable", new { id = newTable.TableId }, newTable);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTable(int id, [FromBody] UpdateTableDTO tableDto)
        {
            var table = await _context.Tables.FindAsync(id);

            if (table == null)
            {
                return NotFound("Table not found.");
            }

            // Update the table entity with data from the DTO
            table.IsAvailable = tableDto.IsAvailable;

            // Save the changes
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TableExists(int id)
        {
            return _context.Tables.Any(e => e.TableId == id);
        }
    }

}
