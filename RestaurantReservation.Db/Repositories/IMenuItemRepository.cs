using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IMenuItemRepository
    {
        /// <summary>
        /// Adds a new menu item to the database.
        /// </summary>
        /// <param name="newMenuItem"></param>
        /// <returns>The ID of the added menu item.</returns>
        public Task<int> CreateAsync(MenuItemDTO newMenuItem);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<MenuItemDTO> GetAsync(int menuItemId);

        public Task<List<MenuItemDTO>> GetAllAsync();

        public Task UpdateAsync(MenuItemDTO updatedMenuItem);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int menuItemId);
    }
}
