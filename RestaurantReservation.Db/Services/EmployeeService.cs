using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class EmployeeService
    {
        private RestaurantReservationDbContext _context = new();
        private EmployeesRepository employeesRepository;

        public EmployeeService(RestaurantReservationDbContext context = null)
        {
            _context = context ?? new();
            employeesRepository = new(_context);
        }

        ~EmployeeService()
        {
            _context.DisposeAsync();
        }

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(EmployeeDTO newEmployee)
        {
            return await employeesRepository.CreateAsync(newEmployee);
        }

        public async Task<EmployeeDTO> GetAsync(int employeeId)
        {
            return await employeesRepository.GetAsync(employeeId);
        }

        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            return await employeesRepository.GetAllAsync();
        }

        public async Task UpdateAsync(EmployeeDTO updatedEmployee)
        {
            await employeesRepository.UpdateAsync(updatedEmployee);
        }

        public async Task DeleteAsync(int employeeId)
        {
            await employeesRepository.DeleteAsync(employeeId);
        }

        public async Task<List<EmployeeDTO>> ListManagersAsync()
        {
            var employees = await GetAllAsync();
            return employees.Where(employee => employee.Position == "Manager")
                .ToList();
        }
    }
}
