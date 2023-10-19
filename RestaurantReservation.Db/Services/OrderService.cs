using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class OrderService
    {
        private RestaurantReservationDbContext _context;
        private OrderRepository ordersRepository;

        public OrderService(RestaurantReservationDbContext context)
        {
            _context = context;
            ordersRepository = new(_context);
        }

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(OrderDTO newOrder)
        {
            return await ordersRepository.CreateAsync(newOrder);
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<OrderDTO> GetAsync(int orderId)
        {
            return await ordersRepository.GetAsync(orderId);
        }

        public async Task<List<OrderDTO>> GetAllAsync()
        {
            return await ordersRepository.GetAllAsync();
        }

        public async Task UpdateAsync(OrderDTO updatedOrder)
        {
            await ordersRepository.UpdateAsync(updatedOrder);
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task DeleteAsync(int orderId)
        {
            await ordersRepository.DeleteAsync(orderId);
        }

        public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
        {
            var orders = await GetAllAsync();
            orders = orders.Where(order => order.EmployeeId == employeeId)
                .ToList();

            if (orders.Count > 0)
            {
                return orders.Average(order => order.TotalAmount);
            }

            return 0;
        }

        public async Task<List<OrderDTO>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            return await ordersRepository.DbSet
                .Where(order => order.ReservationId == reservationId)
                .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.MenuItem)
                .ToListAsync();
        }
    }
}
