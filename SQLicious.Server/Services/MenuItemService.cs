﻿using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Model.DTOs.MenuItem;
using SQLicious.Server.Model;
using SQLicious.Server.Services.IServices;
using SQLicious.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace SQLicious.Server.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly RestaurantContext _context;

        public MenuItemService(IMenuItemRepository menuItemRepository, RestaurantContext context)
        {
            _menuItemRepository = menuItemRepository;
            _context = context;
        }
        public async Task CreateMenuItemAsync(MenuItemDTO menuItem)
        {
            try
            {
                var newMenuItem = new MenuItems
                {
                    Name = menuItem.Name,
                    Price = menuItem.Price,
                    IsAvailable = menuItem.IsAvailable,
                    Description = menuItem.Description,
                    MenuType = menuItem.MenuType
                };

                await _menuItemRepository.CreateMenuItemAsync(newMenuItem);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to create the Menu Item: {ex.Message}");
            }
        }

        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            try
            {
                await _menuItemRepository.DeleteMenuItemAsync(menuItemId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to delete the Menu Item: {ex.Message}");
            }
        }

        public async Task<IEnumerable<MenuItems>> GetAllMenuItemsAsync()
        {
            try
            {
                var listOfMenuItems = await _menuItemRepository.GetAllMenuItemsAsync();

                return listOfMenuItems.Select(i => new MenuItems
                {
                    MenuItemId = i.MenuItemId,
                    Name = i.Name,
                    Price = i.Price,
                    IsAvailable = i.IsAvailable,
                    Description = i.Description,
                    MenuType = i.MenuType
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<MenuItems> GetMenuItemByIdAsync(int menuItemId)
        {
            try
            {
                var menuItem = await _menuItemRepository.GetMenuItemByIdAsync(menuItemId);

                return menuItem;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        //Future Implementation
        public async Task<IEnumerable<MenuItems>> GetThisWeeksMenu()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMenuItemAsync(MenuItems menuItem)
        {
            try
            {
                if (menuItem != null)
                {
                    var updatedMenuItem = new MenuItems
                    {
                        MenuItemId = menuItem.MenuItemId,
                        Name = menuItem.Name,
                        Price = menuItem.Price,
                        IsAvailable = menuItem.IsAvailable,
                        Description = menuItem.Description,
                        MenuType = menuItem.MenuType
                    };

                    await _menuItemRepository.UpdateMenuItemAsync(updatedMenuItem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to update the Menu Item: {ex.Message}");
            }
        }

        public async Task<IEnumerable<PDFMenuItemDTO>> GetMenuItemsByTypeAsync(MenuType menuType)
        {
            // Query the database for menu items that match the specified MenuType
            var menuItems = await _context.MenuItems
                .Where(mi => mi.MenuType == menuType)
                .Select(mi => new PDFMenuItemDTO
                {
                    MenuItemId = mi.MenuItemId,
                    Name = mi.Name,
                    Description = mi.Description,
                    Price = mi.Price,
                    IsAvailable = mi.IsAvailable,
                    MenuType = mi.MenuType
                })
                .ToListAsync();

            return menuItems;
        }
    }
}