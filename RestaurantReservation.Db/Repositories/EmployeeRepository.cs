using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private RestaurantReservationDbContext _context;

        public EmployeeRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }
        
        public async Task<int> CreateAsync(Employee newEmployee)
        {
            if (newEmployee.Id < 0)
            {
                throw new Exception("Id property can't be negative.");
            }
            if (await EmployeeExistsAsync(newEmployee.Id))
            {
                throw new Exception($"The employee Id {newEmployee.Id} already exists.");
            }

            var employee = await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return employee.Entity.Id;
        }

        public async Task<Employee> GetAsync(int employeeId)
        {
            var employee = await _context.Employees
                .SingleOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID = {employeeId} does not exist.");
            }
            
            return employee;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task UpdateAsync(Employee updatedEmployee)
        {
            if (!(await EmployeeExistsAsync(updatedEmployee.Id)))
            {
                throw new KeyNotFoundException($"Employee with ID = {updatedEmployee.Id} does not exist.");
            }

            _context.Employees.Update(updatedEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employee = await GetAsync(employeeId);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> EmployeeExistsAsync(int employeeId)
        {
            return await _context.Employees.AnyAsync(employee => employee.Id == employeeId);
        }
    }
}
