using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs;
using SQLicious.Server.Services.IServices;

namespace SQLicious.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet("{menuItemId}")]
        public async Task<ActionResult<MenuItems>> GetMenuItemById(int menuItemId)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);
            return Ok(menuItem);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateMenuItem(MenuItemDTO menuItem)
        {
            await _menuItemService.CreateMenuItemAsync(menuItem);
            return Ok("Menu item created successfully.");
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateMenuItem(MenuItems menuItem)
        {
            await _menuItemService.UpdateMenuItemAsync(menuItem);
            return Ok("Menu item updated successfully.");
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteMenuItem(int menuItemId)
        {
            await _menuItemService.DeleteMenuItemAsync(menuItemId);
            return Ok("Menu item deleted successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItems>>> GetAllMenuItems()
        {
            var listOfMenuItems = await _menuItemService.GetAllMenuItemsAsync();
            return Ok(listOfMenuItems);
        }
    }
}