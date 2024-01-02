using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Services
{
    public interface IOrderItemService
    {
        /// <summary>
        /// Adds a new order item to the database.
        /// </summary>
        /// <param name="newOrderItem"></param>
        /// <returns>The ID of the added order item.</returns>
        public Task<int> CreateAsync(OrderItem newOrderItem);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<OrderItem> GetAsync(int orderItemId);

        public Task<List<OrderItem>> GetAllAsync();

        public Task UpdateAsync(OrderItem updatedOrderItem);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int orderItemId);
    }
}