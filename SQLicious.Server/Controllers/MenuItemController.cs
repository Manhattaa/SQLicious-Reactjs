using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLicious.Server.Data;
using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs.Booking;
using SQLicious.Server.Model.DTOs.MenuItem;
using SQLicious.Server.Services;
using SQLicious.Server.Services.IServices;

namespace SQLicious.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        private readonly RestaurantContext _context;
        private readonly IPDFService _pdfService;
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuItemController(IMenuItemService menuItemService, RestaurantContext context, IPDFService pfService, IHttpClientFactory httpClientFactory)
        {
            _menuItemService = menuItemService;
            _context = context;
            _pdfService = pfService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{menuItemId}")]
        public async Task<ActionResult<MenuItemDTO>> GetMenuItemById(int menuItemId)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);
            return Ok(menuItem);
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateMenuItem([FromBody] MenuItemCreationDTO menuItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menuItem = new MenuItems
            {
                Name = menuItemDto.Name,
                Description = menuItemDto.Description,
                Price = menuItemDto.Price,
                IsAvailable = menuItemDto.IsAvailable,
                MenuType = menuItemDto.MenuType
            };

            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }

        [HttpGet("generatepdf/{menuType}")]
        public async Task<IActionResult> GenerateMenuPdf(MenuType menuType)
        {
            var menuItems = await _menuItemService.GetMenuItemsByTypeAsync(menuType);

            var pdf = _pdfService.GenerateMenuPdf(menuItems, menuType.ToString());

            return File(pdf, "application/pdf", $"{menuType}_Menu.pdf");
        }

        [HttpPost("generatepdf/{menuType}")]
        public async Task<IActionResult> GeneratePdf(string menuType)
        {
            // Convert the string menuType to the MenuType enum
            if (!Enum.TryParse(menuType, true, out MenuType parsedMenuType))
            {
                return BadRequest("Invalid MenuType");
            }

            // Fetch menu items for the parsed MenuType
            var menuItems = await _menuItemService.GetMenuItemsByTypeAsync(parsedMenuType);

            // Generate the PDF
            var pdfBytes = _pdfService.GenerateMenuPdf(menuItems, menuType);

            // Define the path to save the PDF
            var pdfDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfs");
            var pdfFileName = $"{parsedMenuType}_Menu.pdf";  // Use the parsed enum name
            var filePath = Path.Combine(pdfDirectory, pdfFileName);

            // Ensure the directory exists
            if (!Directory.Exists(pdfDirectory))
            {
                Directory.CreateDirectory(pdfDirectory);
            }

            // Save the PDF file
            await System.IO.File.WriteAllBytesAsync(filePath, pdfBytes);

            // Return the URL to the stored PDF file
            var pdfUrl = $"{Request.Scheme}://{Request.Host}/pdfs/{pdfFileName}";
            return Ok(new { pdfUrl });
        }


        [HttpPut("update/{menuItemId}")]
        public async Task<ActionResult> UpdateMenuItem(int menuItemId, [FromBody] UpdateMenuItemDTO menuItemDto)
        {
            // Fetch the existing menu item from the database
            var existingMenuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);

            if (existingMenuItem == null)
            {
                return NotFound("MenuItem not found.");
            }

            // Update the properties
            existingMenuItem.Name = menuItemDto.Name;
            existingMenuItem.Description = menuItemDto.Description;
            existingMenuItem.Price = menuItemDto.Price;
            existingMenuItem.IsAvailable = menuItemDto.IsAvailable;
            existingMenuItem.MenuType = menuItemDto.MenuType;

            // Save the changes
            await _menuItemService.UpdateMenuItemAsync(existingMenuItem);

            return Ok("MenuItem updated successfully.");
        }

        [HttpDelete("delete")]
            public async Task<ActionResult> DeleteMenuItem(int menuItemId)
            {
                await _menuItemService.DeleteMenuItemAsync(menuItemId);
                return Ok("MenuItem deleted successfully.");
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<MenuItemDTO>>> GetAllMenuItems()
            {
                var menuItemsList = await _menuItemService.GetAllMenuItemsAsync();
                return Ok(menuItemsList);
            }
        }
    }
