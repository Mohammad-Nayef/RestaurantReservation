using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Adds the new customer to the database.
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns>The ID of the added customer.</returns>
        Task<int> CreateAsync(Customer newCustomer);

        /// <exception cref="KeyNotFoundException"></exception>
        Task<Customer> GetAsync(int customerId);

        Task<List<Customer>> GetAllAsync();
        
        /// <summary>
        /// Gets a page of the collection ordered by the name.
        /// </summary>
        /// <param name="pageNumber">Number of the needed page.</param>
        /// <param name="pageSize">Number of elements the page contains.</param>
        /// <returns></returns>
        Task<List<Customer>> GetAllAsync(int pageNumber, int pageSize);

        /// <exception cref="KeyNotFoundException"></exception>
        Task UpdateAsync(Customer updatedCustomer);

        /// <exception cref="KeyNotFoundException"></exception>
        Task DeleteAsync(int customerId);

        Task<List<Customer>> GetCustomersWithPartySizeGreaterThanValueAsync(int value);

        Task<int> GetCustomersCountAsync();
    }
}