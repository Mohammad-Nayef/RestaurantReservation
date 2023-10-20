using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class RestaurantService : IRestaurantService
    {
        private RestaurantReservationDbContext _context;
        private RestaurantRepository restaurantsRepository;

        public RestaurantService(RestaurantReservationDbContext context)
        {
            _context = context;
            restaurantsRepository = new(_context);
        }

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

        public async Task<int> TotalRevenueAsync(int restaurantId)
        {
            return await restaurantsRepository.GetTotalRevenueAsync(restaurantId);
        }
    }
}
