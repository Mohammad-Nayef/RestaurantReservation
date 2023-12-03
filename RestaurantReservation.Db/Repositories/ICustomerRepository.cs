using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface ICustomerRepository
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
        /// <param name="skipCount">Number of values to skip from the beginning of the collection.</param>
        /// <param name="takeCount">Number of values to take after the skipped values.</param>
        Task<List<CustomerDTO>> GetAllAsync(int skipCount, int takeCount);

        Task UpdateAsync(CustomerDTO updatedCustomer);

        /// <exception cref="KeyNotFoundException"></exception>
        Task DeleteAsync(int customerId);

        Task<List<CustomerDTO>> GetCustomersWithPartySizeGreaterThanValueAsync(int value);

        int GetCustomersCount();
    }
}
