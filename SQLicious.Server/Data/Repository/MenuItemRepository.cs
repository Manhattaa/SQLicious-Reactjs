using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace SQLicious.Server.Data.Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantContext _context;

        public MenuItemRepository(RestaurantContext context)
        {
            _context = context;
        }
        public async Task CreateMenuItemAsync(MenuItems menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            var menuItem = await _context.MenuItems.FindAsync(menuItemId);

            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MenuItems>> GetAllMenuItemsAsync()
        {
            var listOfAllMenuItems = await _context.MenuItems.ToListAsync();
            return listOfAllMenuItems;
        }

        public async Task<MenuItems> GetMenuItemByIdAsync(int menuItemId)
        {
            var menuItem = await _context.MenuItems.FindAsync(menuItemId);
            return menuItem;
        }

        public async Task UpdateMenuItemAsync(MenuItems menuItem)
        {
            var existingMenuItem = await _context.MenuItems.FindAsync(menuItem.MenuItemId);
            if (existingMenuItem != null)
            {
                // Update the tracked entity
                _context.Entry(existingMenuItem).CurrentValues.SetValues(menuItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}