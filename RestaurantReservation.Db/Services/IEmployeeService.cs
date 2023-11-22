using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns>The ID of the added employee.</returns>
        public Task<int> CreateAsync(EmployeeDTO newEmployee);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<EmployeeDTO> GetAsync(int employeeId);

        public Task<List<EmployeeDTO>> GetAllAsync();

        public Task UpdateAsync(EmployeeDTO updatedEmployee);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int employeeId);

        public Task<List<EmployeeDTO>> ListManagersAsync();
    }
}