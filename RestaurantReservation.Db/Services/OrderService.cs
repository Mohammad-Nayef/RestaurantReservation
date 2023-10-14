using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class OrderService
    {
        private RestaurantReservationDbContext _context = new();
        private OrdersRepository ordersRepository;

        public OrderService()
        {
            ordersRepository = new(_context);
        }

        ~OrderService()
        {
            _context.DisposeAsync();
        }

        public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
        {
            var orders = await ordersRepository.GetAllAsync();
            return orders.Where(order => order.EmployeeId == employeeId)
                .Average(order => order.TotalAmount);
        }
    }
}
