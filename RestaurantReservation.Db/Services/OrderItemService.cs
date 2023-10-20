using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class OrderItemService : IOrderItemService
    {
        private RestaurantReservationDbContext _context;
        private OrderItemRepository orderItemsRepository;

        public OrderItemService(RestaurantReservationDbContext context)
        {
            _context = context;
            orderItemsRepository = new(_context);
        }

        public async Task<int> CreateAsync(OrderItemDTO newOrderItem)
        {
            return await orderItemsRepository.CreateAsync(newOrderItem);
        }

        public async Task<OrderItemDTO> GetAsync(int orderItemId)
        {
            return await orderItemsRepository.GetAsync(orderItemId);
        }

        public async Task<List<OrderItemDTO>> GetAllAsync()
        {
            return await orderItemsRepository.GetAllAsync();
        }

        public async Task UpdateAsync(OrderItemDTO updatedOrderItem)
        {
            await orderItemsRepository.UpdateAsync(updatedOrderItem);
        }

        public async Task DeleteAsync(int orderItemId)
        {
            await orderItemsRepository.DeleteAsync(orderItemId);
        }
    }
}
