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

        public async Task<int> CreateAsync(Customer newCustomer) =>
            await _customersRepository.CreateAsync(newCustomer);

        public async Task<Customer> GetAsync(int customerId) =>
            await _customersRepository.GetAsync(customerId);

        public async Task<List<Customer>> GetAllAsync() =>
            await _customersRepository.GetAllAsync();

        public async Task<List<Customer>> GetAllAsync(int pageNumber, int pageSize) =>
            await _customersRepository.GetAllAsync(
                (pageNumber - 1) * pageSize, pageSize);

        public async Task UpdateAsync(Customer updatedCustomer) =>
            await _customersRepository.UpdateAsync(updatedCustomer);

        public async Task DeleteAsync(int customerId) =>
            await _customersRepository.DeleteAsync(customerId);

        public async Task<List<Customer>> GetCustomersWithPartySizeGreaterThanValueAsync(
            int value) =>
            await _customersRepository.
                GetCustomersWithPartySizeGreaterThanValueAsync(value);

        public async Task<int> GetCustomersCountAsync() =>
            await _customersRepository.GetCustomersCountAsync();

        public async Task<bool> CustomerExistsAsync(int customerId) =>
            await _customersRepository.CustomerExistsAsync(customerId);
    }
}
