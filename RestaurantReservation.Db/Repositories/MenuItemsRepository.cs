using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemsRepository
    {
        private RestaurantReservationDbContext _context;

        public MenuItemsRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(MenuItemDTO newMenuItem)
        {
            var menuItem = await _context.MenuItems.AddAsync(newMenuItem);
            await _context.SaveChangesAsync();
            return menuItem.Entity.Id;
        }

        public async Task<MenuItemDTO> GetAsync(int menuItemId)
        {
            var menuItem = await _context.MenuItems
                .SingleOrDefaultAsync(item => item.Id == menuItemId);

            if (menuItem != null)
            {
                return menuItem;
            }
            else
            {
                throw new KeyNotFoundException($"Menu item with ID = {menuItemId} does not exist.");
            }
        }

        public async Task<List<MenuItemDTO>> GetAllAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task UpdateAsync(MenuItemDTO updatedMenuItem)
        {
            _context.MenuItems.Update(updatedMenuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int menuItemId)
        {
            var menuItem = await GetAsync(menuItemId);
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
        }
    }
}
