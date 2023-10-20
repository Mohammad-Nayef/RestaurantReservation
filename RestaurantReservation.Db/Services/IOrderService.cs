using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Services
{
    public interface IOrderService
    {
        /// <returns>The ID of the created object.</returns>
        public Task<int> CreateAsync(OrderDTO newOrder);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<OrderDTO> GetAsync(int orderId);

        public Task<List<OrderDTO>> GetAllAsync();

        public Task UpdateAsync(OrderDTO updatedOrder);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int orderId);

        public Task<double> CalculateAverageOrderAmountAsync(int employeeId);

        public Task<List<OrderDTO>> ListOrdersAndMenuItemsAsync(int reservationId);
    }
}