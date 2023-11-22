using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Services
{
    public interface IOrderItemService
    {
        /// <summary>
        /// Adds a new order item to the database.
        /// </summary>
        /// <param name="newOrderItem"></param>
        /// <returns>The ID of the added order item.</returns>
        public Task<int> CreateAsync(OrderItemDTO newOrderItem);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<OrderItemDTO> GetAsync(int orderItemId);

        public Task<List<OrderItemDTO>> GetAllAsync();

        public Task UpdateAsync(OrderItemDTO updatedOrderItem);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int orderItemId);
    }
}