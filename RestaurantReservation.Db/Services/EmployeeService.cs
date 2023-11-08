using RestaurantReservation.Db.Models;
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

        public async Task<int> CreateAsync(EmployeeDTO newEmployee)
        {
            return await _employeesRepository.CreateAsync(newEmployee);
        }

        public async Task<EmployeeDTO> GetAsync(int employeeId)
        {
            return await _employeesRepository.GetAsync(employeeId);
        }

        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            return await _employeesRepository.GetAllAsync();
        }

        public async Task UpdateAsync(EmployeeDTO updatedEmployee)
        {
            await _employeesRepository.UpdateAsync(updatedEmployee);
        }

        public async Task DeleteAsync(int employeeId)
        {
            await _employeesRepository.DeleteAsync(employeeId);
        }

        public async Task<List<EmployeeDTO>> ListManagersAsync()
        {
            var employees = await GetAllAsync();
            return employees.Where(employee => employee.Position == EmployeePositions.Manager)
                .ToList();
        }
    }
}
