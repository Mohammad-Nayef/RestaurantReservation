using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemsRepository
    {
        private RestaurantReservationDbContext _context;

        public OrderItemsRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public DbSet<OrderItemDTO> DbSet => _context.OrderItems;

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(OrderItemDTO newOrderItem)
        {
            var orderItem = await _context.OrderItems.AddAsync(newOrderItem);
            await _context.SaveChangesAsync();
            return orderItem.Entity.Id;
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<OrderItemDTO> GetAsync(int orderItemId)
        {
            var orderItem = await _context.OrderItems
                .SingleOrDefaultAsync(item => item.Id == orderItemId);

            if (orderItem != null)
            {
                return orderItem;
            }
            else
            {
                throw new KeyNotFoundException($"Order item with ID = {orderItemId} does not exist.");
            }
        }

        public async Task<List<OrderItemDTO>> GetAllAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task UpdateAsync(OrderItemDTO updatedOrderItem)
        {
            _context.OrderItems.Update(updatedOrderItem);
            await _context.SaveChangesAsync();
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task DeleteAsync(int orderItemId)
        {
            var orderItem = await GetAsync(orderItemId);
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}
