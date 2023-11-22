using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private RestaurantReservationDbContext _context;

        public RestaurantRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<int> CreateAsync(RestaurantDTO newRestaurant)
        {
            if (newRestaurant.Id < 0)
            {
                throw new Exception("Id property can't be negative.");
            }
            if (await RestaurantExistsAsync(newRestaurant.Id))
            {
                throw new Exception($"The restaurant Id {newRestaurant.Id} already exists.");
            }

            var restaurant = await _context.Restaurants.AddAsync(newRestaurant);
            await _context.SaveChangesAsync();
            return restaurant.Entity.Id;
        }

        public async Task<RestaurantDTO> GetAsync(int restaurantId)
        {
            var restaurant = await _context.Restaurants
                .SingleOrDefaultAsync(r => r.Id == restaurantId);

            if (restaurant == null)
            {
                throw new KeyNotFoundException($"Restaurant with ID = {restaurantId} does not exist.");
            }
            
            return restaurant;
        }

        public async Task<List<RestaurantDTO>> GetAllAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task UpdateAsync(RestaurantDTO updatedRestaurant)
        {
            if (!(await RestaurantExistsAsync(updatedRestaurant.Id)))
            {
                throw new KeyNotFoundException($"Restaurant with ID = {updatedRestaurant.Id} does not exist.");
            }

            _context.Restaurants.Update(updatedRestaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int restaurantId)
        {
            var restaurant = await GetAsync(restaurantId);
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetTotalRevenueAsync(int restaurantId)
        {
            // The database function is already mapped to EF Core which can be found in
            // context class: TotalRevenueByRestaurant().
            // However, because it can't be used as a single statement, I had to execute it using
            // raw Sql. For more info check out this issue: https://github.com/dotnet/efcore/issues/32056

            return (await _context.Database
                .SqlQuery<int>($"SELECT dbo.fn_TotalRevenue({restaurantId})")
                .ToListAsync())
                .FirstOrDefault();
        }

        private async Task<bool> RestaurantExistsAsync(int restaurantId)
        {
            return await _context.Restaurants.AnyAsync(restaurant => restaurant.Id == restaurantId);
        }
    }
}
