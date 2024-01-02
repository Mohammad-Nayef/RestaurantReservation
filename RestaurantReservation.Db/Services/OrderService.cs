using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class OrderService : IOrderService
    {
        private RestaurantReservationDbContext _context;
        private OrderRepository _ordersRepository;

        public OrderService(RestaurantReservationDbContext context)
        {
            _context = context;
            _ordersRepository = new(_context);
        }

        public async Task<int> CreateAsync(Order newOrder)
        {
            return await _ordersRepository.CreateAsync(newOrder);
        }

        public async Task<Order> GetAsync(int orderId)
        {
            return await _ordersRepository.GetAsync(orderId);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _ordersRepository.GetAllAsync();
        }

        public async Task UpdateAsync(Order updatedOrder)
        {
            await _ordersRepository.UpdateAsync(updatedOrder);
        }

        public async Task DeleteAsync(int orderId)
        {
            await _ordersRepository.DeleteAsync(orderId);
        }
    }
}
