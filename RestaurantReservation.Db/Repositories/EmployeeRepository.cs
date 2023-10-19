﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

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
        
        public async Task<int> CreateAsync(EmployeeDTO newEmployee)
        {
            var employee = await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return employee.Entity.Id;
        }

        public async Task<EmployeeDTO> GetAsync(int employeeId)
        {
            var employee = await _context.Employees
                .SingleOrDefaultAsync(e => e.Id == employeeId);

            if (employee != null)
            {
                return employee;
            }
            else
            {
                throw new KeyNotFoundException($"Employee with ID = {employeeId} does not exist.");
            }
        }

        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task UpdateAsync(EmployeeDTO updatedEmployee)
        {
            _context.Employees.Update(updatedEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employee = await GetAsync(employeeId);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}