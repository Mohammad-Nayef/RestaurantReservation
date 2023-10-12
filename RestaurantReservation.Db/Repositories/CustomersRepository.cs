using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public static class CustomersRepository
    {
        public static async Task<Customer?> GetAsync(int customerId)
        {
            using (var context = new RestaurantReservationDbContext())
            {
                return await context.Customers
                    .SingleOrDefaultAsync(customer => customer.Id == customerId);
            }
        }

        public static async Task<List<Customer>> GetAllAsync()
        {
            using (var context = new RestaurantReservationDbContext())
            {
                return await context.Customers.ToListAsync();
            }
        }
    }
}
