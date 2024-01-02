using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

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

        public async Task<int> CreateAsync(Customer newCustomer)
        {
            if (newCustomer.Id < 0)
            {
                throw new Exception("Id property can't be negative.");
            }
            if (await CustomerExistsAsync(newCustomer.Id))
            {
                throw new Exception($"The customer Id {newCustomer.Id} already exists.");
            }

            var customer = await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
            return customer.Entity.Id;
        }

        public async Task<Customer> GetAsync(int customerId)
        {
            var customer = await _context.Customers
                .SingleOrDefaultAsync(customer => customer.Id == customerId);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID = {customerId} does not exist.");
            }

            return customer;
        }

        public async Task<List<Customer>> GetAllAsync() =>
            await _context.Customers.ToListAsync();

        public async Task<List<Customer>> GetAllAsync(int skipCount, int takeCount)
        {
            return await _context.Customers
                .OrderBy(customer => customer.FirstName)
                .ThenBy(customer => customer.LastName)
                .Skip(skipCount)
                .Take(takeCount)
                .ToListAsync();
        }

        public async Task UpdateAsync(Customer updatedCustomer)
        {
            if (!(await CustomerExistsAsync(updatedCustomer.Id)))
            {
                throw new KeyNotFoundException(
                    $"Customer with ID = {updatedCustomer.Id} does not exist.");
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

        public async Task<List<Customer>> GetCustomersWithPartySizeGreaterThanValueAsync(
            int value)
        {
            return await _context.Customers
                .FromSql($"EXEC sp_GetCustomersWithPartySizeGreaterThanValue {value}")
                .ToListAsync();
        }

        public async Task<bool> CustomerExistsAsync(int customerId) =>
            await _context.Customers.AnyAsync(customer => customer.Id == customerId);

        public async Task<int> GetCustomersCountAsync()
        {
            if (_context.Customers.TryGetNonEnumeratedCount(out var fastCount))
                return fastCount;

            return await _context.Customers.CountAsync();
        }
    }
}
