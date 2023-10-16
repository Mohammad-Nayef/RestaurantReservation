using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class CustomersRepository
    {
        private RestaurantReservationDbContext _context;

        public CustomersRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public DbSet<CustomerDTO> DbSet => _context.Customers;

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(CustomerDTO newCustomer)
        {
            var customer = await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
            return customer.Entity.Id;
        }

        public async Task<CustomerDTO> GetAsync(int customerId)
        {
            var customer = await _context.Customers
                .SingleOrDefaultAsync(customer => customer.Id == customerId);

            if (customer != null)
            {
                return customer;
            }
            else
            {
                throw new KeyNotFoundException(
                    $"Customer with ID = {customerId} does not exist.");
            }
        }

        public async Task<List<CustomerDTO>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task UpdateAsync(CustomerDTO updatedCustomer)
        {
            _context.Customers.Update(updatedCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int customerId)
        {
            var customer = await GetAsync(customerId);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CustomerDTO>> GetCustomersWithPartySizeGreaterThanValueAsync(int value)
        {
            return await _context.Customers
                .FromSql($"EXEC sp_GetCustomersWithPartySizeGreaterThanValue {value}")
                .ToListAsync();
        }
    }
}
