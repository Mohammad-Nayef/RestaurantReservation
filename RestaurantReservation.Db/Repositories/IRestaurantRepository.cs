using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public interface IRestaurantRepository
    {
        /// <summary>
        /// Adds a new restaurant to the database.
        /// </summary>
        /// <param name="newRestaurant"></param>
        /// <returns>The ID of the added restaurant.</returns>
        public Task<int> CreateAsync(Restaurant newRestaurant);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<Restaurant> GetAsync(int restaurantId);

        public Task<List<Restaurant>> GetAllAsync();

        public Task UpdateAsync(Restaurant updatedRestaurant);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int restaurantId);

        public Task<int> GetTotalRevenueAsync(int restaurantId);
    }
}
