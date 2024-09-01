using SQLicious.Server.Model;
using SQLicious.Server.Services.IServices;

namespace SQLicious.Server.Services
{
    public class MenuItemService : IMenuItemService
    {
        public Task CreateMenuItemAsync(MenuItems menuItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMenuItemAsync(int menuItemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MenuItems>> GetAllMenuItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MenuItems> GetMenuItemByIdAsync(int menuItemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MenuItems>> GetThisWeeksMenu()
        {
            throw new NotImplementedException();
        }

        public Task UpdateMenuItemAsync(MenuItems menuItem)
        {
            throw new NotImplementedException();
        }
    }
}
