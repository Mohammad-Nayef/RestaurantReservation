using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository _employeesRepository;
        private IOrderService _orderService;

        public EmployeeService(
            RestaurantReservationDbContext context,
            IOrderService orderService)
        {
            _employeesRepository = new(context);
            _orderService = orderService;
        }

        public async Task<int> CreateAsync(Employee newEmployee) =>
            await _employeesRepository.CreateAsync(newEmployee);

        public async Task<Employee> GetAsync(int employeeId) =>
            await _employeesRepository.GetAsync(employeeId);

        public async Task<List<Employee>> GetAllAsync() =>
            await _employeesRepository.GetAllAsync();

        public async Task<List<Employee>> GetAllAsync(int pageNumber, int pageSize) =>
            await _employeesRepository.GetAllAsync(
                (pageNumber - 1) * pageSize, pageSize);

        public async Task UpdateAsync(Employee updatedEmployee) =>
            await _employeesRepository.UpdateAsync(updatedEmployee);

        public async Task DeleteAsync(int employeeId) =>
            await _employeesRepository.DeleteAsync(employeeId);

        public async Task<List<Employee>> ListManagersAsync(int pageNumber, int pageSize) =>
            await _employeesRepository.ListManagersAsync(
                (pageNumber - 1) * pageSize, pageSize);

        public async Task<int> GetEmployeesCountAsync() => 
            await _employeesRepository.GetEmployeesCountAsync();
        
        public async Task<int> GetManagersCountAsync() => 
            await _employeesRepository.GetManagersCountAsync();

        public async Task<bool> EmployeeExistsAsync(int employeeId) =>
            await _employeesRepository.EmployeeExistsAsync(employeeId);

        public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
        {
            var orders = await _orderService.GetAllAsync();
            orders = orders.Where(order => order.EmployeeId == employeeId)
                .ToList();

            if (orders.Count > 0)
            {
                return orders.Average(order => order.TotalAmount);
            }

            return 0;
        }
    }
}
