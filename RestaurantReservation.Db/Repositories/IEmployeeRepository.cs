using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns>The ID of the added employee.</returns>
        Task<int> CreateAsync(Employee newEmployee);

        Task<bool> EmployeeExistsAsync(int employeeId);

        /// <exception cref="KeyNotFoundException"></exception>
        Task<Employee> GetAsync(int employeeId);

        Task<List<Employee>> GetAllAsync();

        /// <summary>
        /// Gets a page of the collection ordered by the name.
        /// </summary>
        /// <param name="skipCount">Number of values to skip from the beginning of the collection.</param>
        /// <param name="takeCount">Number of values to take after the skipped values.</param>
        Task<List<Employee>> GetAllAsync(int skipCount, int takeCount);

        Task<List<Employee>> ListManagersAsync(int skipCount, int takeCount);

        /// <exception cref="KeyNotFoundException"></exception>
        Task UpdateAsync(Employee updatedEmployee);

        /// <exception cref="KeyNotFoundException"></exception>
        Task DeleteAsync(int employeeId);

        Task<int> GetEmployeesCountAsync();

        Task<int> GetManagersCountAsync();
    }
}
