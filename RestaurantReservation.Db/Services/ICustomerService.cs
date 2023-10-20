using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Services
{
    public interface ICustomerService
    {
        /// <returns>The ID of the created object.</returns>
        public Task<int> CreateAsync(CustomerDTO newCustomer);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<CustomerDTO> GetAsync(int customerId);

        public Task<List<CustomerDTO>> GetAllAsync();

        public Task UpdateAsync(CustomerDTO updatedCustomer);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int customerId);

        public Task<List<CustomerDTO>> GetCustomersWithPartySizeGreaterThanValueAsync(int value);
    }
}