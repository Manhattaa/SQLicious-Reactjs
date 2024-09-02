using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs;

namespace SQLicious.Server.Services.IServices
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItems>> GetAllMenuItemsAsync();
        Task<IEnumerable<MenuItems>> GetThisWeeksMenu();
        Task<MenuItems> GetMenuItemByIdAsync(int menuItemId);
        Task CreateMenuItemAsync(MenuItemDTO menuItem);
        Task UpdateMenuItemAsync(MenuItems menuItem);
        Task DeleteMenuItemAsync(int menuItemId);
    }
}
