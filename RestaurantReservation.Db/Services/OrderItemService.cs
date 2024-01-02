using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class OrderItemService : IOrderItemService
    {
        private RestaurantReservationDbContext _context;
        private OrderItemRepository _orderItemsRepository;

        public OrderItemService(RestaurantReservationDbContext context)
        {
            _context = context;
            _orderItemsRepository = new(_context);
        }

        public async Task<int> CreateAsync(OrderItem newOrderItem)
        {
            return await _orderItemsRepository.CreateAsync(newOrderItem);
        }

        public async Task<OrderItem> GetAsync(int orderItemId)
        {
            return await _orderItemsRepository.GetAsync(orderItemId);
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            return await _orderItemsRepository.GetAllAsync();
        }

        public async Task UpdateAsync(OrderItem updatedOrderItem)
        {
            await _orderItemsRepository.UpdateAsync(updatedOrderItem);
        }

        public async Task DeleteAsync(int orderItemId)
        {
            await _orderItemsRepository.DeleteAsync(orderItemId);
        }
    }
}
