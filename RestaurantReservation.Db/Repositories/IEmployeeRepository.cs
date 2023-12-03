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
        public Task<int> CreateAsync(Employee newEmployee);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<Employee> GetAsync(int employeeId);

        public Task<List<Employee>> GetAllAsync();

        public Task UpdateAsync(Employee updatedEmployee);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int employeeId);
    }
}
