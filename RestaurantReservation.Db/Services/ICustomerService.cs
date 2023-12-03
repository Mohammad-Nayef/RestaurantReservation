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
        Task<int> CreateAsync(CustomerDTO newCustomer);

        /// <exception cref="KeyNotFoundException"></exception>
        Task<CustomerDTO> GetAsync(int customerId);

        Task<List<CustomerDTO>> GetAllAsync();
        
        /// <summary>
        /// Gets a page of the collection ordered by the name.
        /// </summary>
        /// <param name="pageNumber">Number of the needed page.</param>
        /// <param name="pageSize">Number of elements the page contains.</param>
        /// <returns></returns>
        Task<List<CustomerDTO>> GetAllAsync(int pageNumber, int pageSize);

        Task UpdateAsync(CustomerDTO updatedCustomer);

        /// <exception cref="KeyNotFoundException"></exception>
        Task DeleteAsync(int customerId);

        Task<List<CustomerDTO>> GetCustomersWithPartySizeGreaterThanValueAsync(int value);
    }
}