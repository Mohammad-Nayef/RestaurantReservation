using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class CustomerService
    {
        private RestaurantReservationDbContext _context;
        private CustomerRepository customersRepository;

        public CustomerService(RestaurantReservationDbContext context)
        {
            _context = context;
            customersRepository = new(_context);
        }

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(CustomerDTO newCustomer)
        {
            return await customersRepository.CreateAsync(newCustomer);
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<CustomerDTO> GetAsync(int customerId)
        {
            return await customersRepository.GetAsync(customerId);
        }

        public async Task<List<CustomerDTO>> GetAllAsync()
        {
            return await customersRepository.GetAllAsync();
        }

        public async Task UpdateAsync(CustomerDTO updatedCustomer)
        {
            await customersRepository.UpdateAsync(updatedCustomer);
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task DeleteAsync(int customerId)
        {
            await customersRepository.DeleteAsync(customerId);
        }

        public async Task<List<CustomerDTO>> GetCustomersWithPartySizeGreaterThanValueAsync(int value)
        {
            return await customersRepository.GetCustomersWithPartySizeGreaterThanValueAsync(value);
        }
    }
}
