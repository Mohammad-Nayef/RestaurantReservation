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
    }
}
