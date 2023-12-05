using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class EmployeeService : IEmployeeService
    {
        private RestaurantReservationDbContext _context;
        private EmployeeRepository _employeesRepository;

        public EmployeeService(RestaurantReservationDbContext context)
        {
            _context = context;
            _employeesRepository = new(_context);
        }

        public async Task<int> CreateAsync(Employee newEmployee)
        {
            return await _employeesRepository.CreateAsync(newEmployee);
        }

        public async Task<Employee> GetAsync(int employeeId)
        {
            return await _employeesRepository.GetAsync(employeeId);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employeesRepository.GetAllAsync();
        }

        public async Task<List<Employee>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _employeesRepository.GetAllAsync(
                (pageNumber - 1) * pageSize, pageSize);
        }

        public async Task UpdateAsync(Employee updatedEmployee)
        {
            await _employeesRepository.UpdateAsync(updatedEmployee);
        }

        public async Task DeleteAsync(int employeeId)
        {
            await _employeesRepository.DeleteAsync(employeeId);
        }

        public async Task<List<Employee>> ListManagersAsync(int pageNumber, int pageSize)
        {
            return await _employeesRepository.ListManagersAsync(
                (pageNumber - 1) * pageSize, pageSize);
        }

        public async Task<int> GetEmployeesCountAsync() => 
            await _employeesRepository.GetEmployeesCountAsync();
        
        public async Task<int> GetManagersCountAsync() => 
            await _employeesRepository.GetManagersCountAsync();
    }
}
