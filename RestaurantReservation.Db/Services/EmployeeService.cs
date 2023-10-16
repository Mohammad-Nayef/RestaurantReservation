using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class EmployeeService
    {
        private RestaurantReservationDbContext _context;
        private EmployeesRepository employeesRepository;

        public EmployeeService(RestaurantReservationDbContext context)
        {
            _context = context;
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

        /// <exception cref="KeyNotFoundException"></exception>
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

        /// <exception cref="KeyNotFoundException"></exception>
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
