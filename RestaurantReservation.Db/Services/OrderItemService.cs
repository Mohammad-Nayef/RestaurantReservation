using RestaurantReservation.Db.Models;
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

        public async Task<int> CreateAsync(OrderItemDTO newOrderItem)
        {
            return await _orderItemsRepository.CreateAsync(newOrderItem);
        }

        public async Task<OrderItemDTO> GetAsync(int orderItemId)
        {
            return await _orderItemsRepository.GetAsync(orderItemId);
        }

        public async Task<List<OrderItemDTO>> GetAllAsync()
        {
            return await _orderItemsRepository.GetAllAsync();
        }

        public async Task UpdateAsync(OrderItemDTO updatedOrderItem)
        {
            await _orderItemsRepository.UpdateAsync(updatedOrderItem);
        }

        public async Task DeleteAsync(int orderItemId)
        {
            await _orderItemsRepository.DeleteAsync(orderItemId);
        }
    }
}
