using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IRestaurantRepository
    {
        /// <returns>The ID of the created object.</returns>
        public Task<int> CreateAsync(RestaurantDTO newRestaurant);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<RestaurantDTO> GetAsync(int restaurantId);

        public Task<List<RestaurantDTO>> GetAllAsync();

        public Task UpdateAsync(RestaurantDTO updatedRestaurant);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int restaurantId);

        public Task<int> GetTotalRevenueAsync(int restaurantId);
    }
}
