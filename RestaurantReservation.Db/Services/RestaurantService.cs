using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class RestaurantService : IRestaurantService
    {
        private RestaurantReservationDbContext _context;
        private RestaurantRepository _restaurantsRepository;

        public RestaurantService(RestaurantReservationDbContext context)
        {
            _context = context;
            _restaurantsRepository = new(_context);
        }

        public async Task<int> CreateAsync(Restaurant newRestaurant)
        {
            return await _restaurantsRepository.CreateAsync(newRestaurant);
        }

        public async Task<Restaurant> GetAsync(int restaurantId)
        {
            return await _restaurantsRepository.GetAsync(restaurantId);
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _restaurantsRepository.GetAllAsync();
        }

        public async Task UpdateAsync(Restaurant updatedRestaurant)
        {
            await _restaurantsRepository.UpdateAsync(updatedRestaurant);
        }

        public async Task DeleteAsync(int restaurantId)
        {
            await _restaurantsRepository.DeleteAsync(restaurantId);
        }

        public async Task<int> TotalRevenueAsync(int restaurantId)
        {
            return await _restaurantsRepository.GetTotalRevenueAsync(restaurantId);
        }
    }
}
