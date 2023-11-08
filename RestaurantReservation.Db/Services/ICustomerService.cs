using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Adds the new customer to the database.
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns>The ID of the added customer.</returns>
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