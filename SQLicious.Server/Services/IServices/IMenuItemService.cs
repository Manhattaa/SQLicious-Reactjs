using SQLicious.Server.Model;

namespace SQLicious.Server.Services.IServices
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItems>> GetAllMenuItemsAsync();
        Task<IEnumerable<MenuItems>> GetThisWeeksMenu();
        Task<MenuItems> GetMenuItemByIdAsync(int menuItemId);
        Task CreateMenuItemAsync(MenuItems menuItem);
        Task UpdateMenuItemAsync(MenuItems menuItem);
        Task DeleteMenuItemAsync(int menuItemId);
    }
}
