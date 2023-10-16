using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantsRepository
    {
        private RestaurantReservationDbContext _context;

        public RestaurantsRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public DbSet<RestaurantDTO> DbSet => _context.Restaurants;

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(RestaurantDTO newRestaurant)
        {
            var restaurant = await _context.Restaurants.AddAsync(newRestaurant);
            await _context.SaveChangesAsync();
            return restaurant.Entity.Id;
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<RestaurantDTO> GetAsync(int restaurantId)
        {
            var restaurant = await _context.Restaurants
                .SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (restaurant != null)
            {
                return restaurant;
            }
            else
            {
                throw new KeyNotFoundException($"Restaurant with ID = {restaurantId} does not exist.");
            }
        }

        public async Task<List<RestaurantDTO>> GetAllAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task UpdateAsync(RestaurantDTO updatedRestaurant)
        {
            _context.Restaurants.Update(updatedRestaurant);
            await _context.SaveChangesAsync();
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task DeleteAsync(int restaurantId)
        {
            var restaurant = await GetAsync(restaurantId);
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }
    }
}
