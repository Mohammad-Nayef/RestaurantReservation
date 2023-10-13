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
    }
}
