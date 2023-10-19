using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IEmployeeRepository
    {
        /// <returns>The ID of the created object.</returns>
        public Task<int> CreateAsync(EmployeeDTO newEmployee);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<EmployeeDTO> GetAsync(int employeeId);

        public Task<List<EmployeeDTO>> GetAllAsync();

        public Task UpdateAsync(EmployeeDTO updatedEmployee);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int employeeId);
    }
}
