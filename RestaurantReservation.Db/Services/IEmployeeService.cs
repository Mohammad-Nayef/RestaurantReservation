using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns>The ID of the added employee.</returns>
        public Task<int> CreateAsync(Employee newEmployee);

        Task<bool> EmployeeExistsAsync(int employeeId);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<Employee> GetAsync(int employeeId);

        /// <summary>
        /// Gets a page of the collection ordered by the name.
        /// </summary>
        /// <param name="pageNumber">Number of the needed page.</param>
        /// <param name="pageSize">Number of elements the page contains.</param>
        /// <returns></returns>
        Task<List<Employee>> GetAllAsync(int pageNumber, int pageSize);

        public Task<List<Employee>> GetAllAsync();

        /// <exception cref="KeyNotFoundException"></exception>
        public Task UpdateAsync(Employee updatedEmployee);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int employeeId);

        /// <summary>
        /// Gets a page of the collection ordered by the name.
        /// </summary>
        /// <param name="pageNumber">Number of the needed page.</param>
        /// <param name="pageSize">Number of elements the page contains.</param>
        /// <returns></returns>
        Task<List<Employee>> ListManagersAsync(int pageNumber, int pageSize);

        Task<int> GetEmployeesCountAsync();

        Task<int> GetManagersCountAsync();

        Task<double> CalculateAverageOrderAmountAsync(int employeeId);
    }
}