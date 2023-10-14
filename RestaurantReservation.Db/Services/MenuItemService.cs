using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class MenuItemService
    {
        private RestaurantReservationDbContext _context = new();
        private MenuItemsRepository menuItemsRepository;

        public MenuItemService(RestaurantReservationDbContext context = null)
        {
            _context = context ?? new();
            menuItemsRepository = new(_context);
        }

        ~MenuItemService()
        {
            _context.DisposeAsync();
        }

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(MenuItemDTO newMenuItem)
        {
            return await menuItemsRepository.CreateAsync(newMenuItem);
        }

        public async Task<MenuItemDTO> GetAsync(int menuItemId)
        {
            return await menuItemsRepository.GetAsync(menuItemId);
        }

        public async Task<List<MenuItemDTO>> GetAllAsync()
        {
            return await menuItemsRepository.GetAllAsync();
        }

        public async Task UpdateAsync(MenuItemDTO updatedMenuItem)
        {
            await menuItemsRepository.UpdateAsync(updatedMenuItem);
        }

        public async Task DeleteAsync(int menuItemId)
        {
            await menuItemsRepository.DeleteAsync(menuItemId);
        }
    }
}
