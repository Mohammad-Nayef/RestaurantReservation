using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Adds a new order to the database.
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns>The ID of the added order.</returns>
        Task<int> CreateAsync(Order newOrder);

        /// <exception cref="KeyNotFoundException"></exception>
        Task<Order> GetAsync(int orderId);

        Task<List<Order>> GetAllAsync();

        Task UpdateAsync(Order updatedOrder);

        /// <exception cref="KeyNotFoundException"></exception>
        Task DeleteAsync(int orderId);
    }
}