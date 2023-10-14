using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class RestaurantService
    {
        private RestaurantReservationDbContext _context = new();
        private RestaurantsRepository restaurantsRepository;

        public RestaurantService()
        {
            restaurantsRepository = new(_context);
        }

        ~RestaurantService()
        {
            _context.DisposeAsync();
        }

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(RestaurantDTO newRestaurant)
        {
            return await restaurantsRepository.CreateAsync(newRestaurant);
        }

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

        public async Task DeleteAsync(int restaurantId)
        {
            await restaurantsRepository.DeleteAsync(restaurantId);
        }
    }
}
