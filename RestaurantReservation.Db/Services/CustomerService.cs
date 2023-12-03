using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class CustomerService : ICustomerService
    {
        private RestaurantReservationDbContext _context;
        private CustomerRepository _customersRepository;

        public CustomerService(RestaurantReservationDbContext context)
        {
            _context = context;
            _customersRepository = new(_context);
        }

        public async Task<int> CreateAsync(CustomerDTO newCustomer)
        {
            return await _customersRepository.CreateAsync(newCustomer);
        }

        public async Task<CustomerDTO> GetAsync(int customerId)
        {
            return await _customersRepository.GetAsync(customerId);
        }

        public async Task<List<CustomerDTO>> GetAllAsync()
        {
            return await _customersRepository.GetAllAsync();
        }

        public async Task<List<CustomerDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _customersRepository.GetAllAsync(
                (pageNumber - 1) * pageSize, pageSize);
        }

        public async Task UpdateAsync(CustomerDTO updatedCustomer)
        {
            await _customersRepository.UpdateAsync(updatedCustomer);
        }

        public async Task DeleteAsync(int customerId)
        {
            await _customersRepository.DeleteAsync(customerId);
        }

        public async Task<List<CustomerDTO>> GetCustomersWithPartySizeGreaterThanValueAsync(
            int value)
        {
            return await _customersRepository.
                GetCustomersWithPartySizeGreaterThanValueAsync(value);
        }
    }
}
