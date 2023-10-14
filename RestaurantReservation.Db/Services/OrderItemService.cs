using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class OrderItemService
    {
        private RestaurantReservationDbContext _context = new();
        private OrderItemsRepository orderItemsRepository;

        public OrderItemService()
        {
            orderItemsRepository = new(_context);
        }

        ~OrderItemService()
        {
            _context.DisposeAsync();
        }

        /// <returns>The ID of the created object.</returns>
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
