using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IMenuItemRepository
    {
        /// <returns>The ID of the created object.</returns>
        public Task<int> CreateAsync(MenuItemDTO newMenuItem);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<MenuItemDTO> GetAsync(int menuItemId);

        public Task<List<MenuItemDTO>> GetAllAsync();

        public Task UpdateAsync(MenuItemDTO updatedMenuItem);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int menuItemId);
    }
}
