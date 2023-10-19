using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class RestaurantService
    {
        private RestaurantReservationDbContext _context;
        private RestaurantsRepository restaurantsRepository;

        public RestaurantService(RestaurantReservationDbContext context)
        {
            _context = context;
            restaurantsRepository = new(_context);
        }

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(RestaurantDTO newRestaurant)
        {
            return await restaurantsRepository.CreateAsync(newRestaurant);
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<RestaurantDTO> GetAsync(int restaurantId)
        {
            return await restaurantsRepository.GetAsync(restaurantId);
        }

        public async Task<List<RestaurantDTO>> GetAllAsync()
        {
            return await restaurantsRepository.GetAllAsync();
        }

        public async Task UpdateAsync(RestaurantDTO updatedRestaurant)
        {
            await restaurantsRepository.UpdateAsync(updatedRestaurant);
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task DeleteAsync(int restaurantId)
        {
            await restaurantsRepository.DeleteAsync(restaurantId);
        }

        public async Task<int> TotalRevenueAsync(int restaurantId)
        {
            return await restaurantsRepository.GetTotalRevenueAsync(restaurantId);
        }
    }
}
