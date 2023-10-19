using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IOrderRepository
    {
        /// <returns>The ID of the created object.</returns>
        public Task<int> CreateAsync(OrderDTO newOrder);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<OrderDTO> GetAsync(int orderId);

        public Task<List<OrderDTO>> GetAllAsync();

        public Task UpdateAsync(OrderDTO updatedOrder);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int orderId);
    }
}
