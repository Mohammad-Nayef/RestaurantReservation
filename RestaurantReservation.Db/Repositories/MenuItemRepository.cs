using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private RestaurantReservationDbContext _context;

        public MenuItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<int> CreateAsync(MenuItem newMenuItem)
        {
            if (newMenuItem.Id < 0)
            {
                throw new Exception("Id property can't be negative.");
            }
            if (await MenuItemExistsAsync(newMenuItem.Id))
            {
                throw new Exception($"The menu item Id {newMenuItem.Id} already exists.");
            }

            var menuItem = await _context.MenuItems.AddAsync(newMenuItem);
            await _context.SaveChangesAsync();
            return menuItem.Entity.Id;
        }

        public async Task<MenuItem> GetAsync(int menuItemId)
        {
            var menuItem = await _context.MenuItems
                .SingleOrDefaultAsync(item => item.Id == menuItemId);

            if (menuItem == null)
            {
                throw new KeyNotFoundException($"Menu item with ID = {menuItemId} does not exist.");
            }
            
            return menuItem;
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task UpdateAsync(MenuItem updatedMenuItem)
        {
            if (!(await MenuItemExistsAsync(updatedMenuItem.Id)))
            {
                throw new KeyNotFoundException($"MenuItem with ID = {updatedMenuItem.Id} does not exist.");
            }

            _context.MenuItems.Update(updatedMenuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int menuItemId)
        {
            var menuItem = await GetAsync(menuItemId);
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> MenuItemExistsAsync(int menuItemId)
        {
            return await _context.MenuItems.AnyAsync(menuItem =>  menuItem.Id == menuItemId);
        }
    }
}
