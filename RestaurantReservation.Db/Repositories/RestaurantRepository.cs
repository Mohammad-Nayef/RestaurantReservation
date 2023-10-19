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
            var restaurant = await _context.Restaurants.AddAsync(newRestaurant);
            await _context.SaveChangesAsync();
            return restaurant.Entity.Id;
        }

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
            using (DbCommand command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"SELECT dbo.fn_TotalRevenue({restaurantId})";
                await _context.Database.OpenConnectionAsync();

                var revenue = (int)await command.ExecuteScalarAsync();

                await _context.Database.CloseConnectionAsync();
                return revenue;
            }
        }
    }
}
