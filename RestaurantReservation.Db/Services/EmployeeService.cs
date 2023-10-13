using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class EmployeeService
    {
        private RestaurantReservationDbContext _context = new();
        private EmployeesRepository employeesRepository;

        public EmployeeService()
        {
            employeesRepository = new(_context);
        }

        ~EmployeeService()
        {
            _context.DisposeAsync();
        }

        public async Task<List<Employee>> ListManagersAsync()
        {
            var employees = await employeesRepository.GetAllAsync();
            return employees.Where(employee => employee.Position == "Manager")
                .ToList();
        }
    }
}
