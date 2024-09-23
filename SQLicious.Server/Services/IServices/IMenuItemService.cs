using SQLicious.Server.Model.DTOs.MenuItem;
using SQLicious.Server.Model;

namespace SQLicious.Server.Services.IServices
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItems>> GetAllMenuItemsAsync();
        Task<MenuItems> GetMenuItemByIdAsync(int menuItemId);
        Task CreateMenuItemAsync(MenuItemDTO menuItem);
        Task UpdateMenuItemAsync(MenuItems menuItem);
        Task DeleteMenuItemAsync(int menuItemId);
        Task<IEnumerable<PDFMenuItemDTO>> GetMenuItemsByTypeAsync(MenuType menuType);
    }
}
