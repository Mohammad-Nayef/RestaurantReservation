using RestaurantReservation.Db.Entities;
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

        public async Task<int> CreateAsync(Customer newCustomer)
        {
            return await _customersRepository.CreateAsync(newCustomer);
        }

        public async Task<Customer> GetAsync(int customerId)
        {
            return await _customersRepository.GetAsync(customerId);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customersRepository.GetAllAsync();
        }

        public async Task<List<Customer>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _customersRepository.GetAllAsync(
                (pageNumber - 1) * pageSize, pageSize);
        }

        public async Task UpdateAsync(Customer updatedCustomer)
        {
            await _customersRepository.UpdateAsync(updatedCustomer);
        }

        public async Task DeleteAsync(int customerId)
        {
            await _customersRepository.DeleteAsync(customerId);
        }

        public async Task<List<Customer>> GetCustomersWithPartySizeGreaterThanValueAsync(
            int value)
        {
            return await _customersRepository.
                GetCustomersWithPartySizeGreaterThanValueAsync(value);
        }

        public int GetCustomersCount() => _customersRepository.GetCustomersCount();
    }
}
