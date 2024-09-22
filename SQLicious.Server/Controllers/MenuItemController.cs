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

        public MenuItemController(IMenuItemService menuItemService, RestaurantContext context)
        {
            _menuItemService = menuItemService;
            _context = context;
        }

        [HttpGet("{menuItemId}")]
        public async Task<ActionResult<MenuItemDTO>> GetMenuItemById(int menuItemId)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);
            return Ok(menuItem);
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateMenuItem(MenuItemCreationDTO menuItemDto)
        {
            
            // Create the menu item
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

            return Ok(menuItem);
        }




        [HttpPut("update")]
            public async Task<ActionResult> UpdateMenuItem(MenuItemDTO menuItemDto)
            {
                var updatedMenuItem = new MenuItems
            {
                Name = menuItemDto.Name,
                Price = menuItemDto.Price,
                IsAvailable = menuItemDto.IsAvailable,
                MenuType = menuItemDto.MenuType,
                Description = menuItemDto.Description
            };
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
