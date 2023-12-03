using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Services
{
    public interface IMenuItemService
    {
        /// <summary>
        /// Adds a new menu item to the database.
        /// </summary>
        /// <param name="newMenuItem"></param>
        /// <returns>The ID of the added menu item.</returns>
        public Task<int> CreateAsync(MenuItem newMenuItem);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<MenuItem> GetAsync(int menuItemId);

        public Task<List<MenuItem>> GetAllAsync();

        public Task UpdateAsync(MenuItem updatedMenuItem);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int menuItemId);

        public Task<List<MenuItem>> ListOrderedMenuItemsAsync(int reservationId);
    }
}