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
        public Task<int> CreateAsync(Order newOrder);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<Order> GetAsync(int orderId);

        public Task<List<Order>> GetAllAsync();

        public Task UpdateAsync(Order updatedOrder);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int orderId);

        public Task<double> CalculateAverageOrderAmountAsync(int employeeId);

        public Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId);
    }
}