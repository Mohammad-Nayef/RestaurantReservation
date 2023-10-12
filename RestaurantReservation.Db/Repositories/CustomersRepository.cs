using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public static class CustomersRepository
    {
        /// <returns>The ID of the created object.</returns>
        public static async Task<int> CreateAsync(Customer newCustomer)
        {
            using (var context = new RestaurantReservationDbContext())
            {
                var customer = await context.Customers.AddAsync(newCustomer);
                await context.SaveChangesAsync();
                return customer.Entity.Id;
            }
        }

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
