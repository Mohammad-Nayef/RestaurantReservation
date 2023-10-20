using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private RestaurantReservationDbContext _context;

        public CustomerRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<int> CreateAsync(CustomerDTO newCustomer)
        {
            if (newCustomer.Id < 0)
            {
                throw new Exception("Id property can't be negative.");
            }
            else if (await CustomerExistsAsync(newCustomer.Id))
            {
                throw new Exception($"The customer Id {newCustomer.Id} already exists.");
            }

            var customer = await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
            return customer.Entity.Id;
        }

        public async Task<CustomerDTO> GetAsync(int customerId)
        {
            var customer = await _context.Customers
                .SingleOrDefaultAsync(customer => customer.Id == customerId);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID = {customerId} does not exist.");
            }
            else
            {
                return customer;
            }
        }

        public async Task<List<CustomerDTO>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task UpdateAsync(CustomerDTO updatedCustomer)
        {
            if (!(await CustomerExistsAsync(updatedCustomer.Id)))
            {
                throw new KeyNotFoundException($"Customer with ID = {updatedCustomer.Id} does not exist.");
            }

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

        private async Task<bool> CustomerExistsAsync(int customerId)
        {
            return await _context.Customers.FindAsync(customerId) != null;
        }
    }
}
