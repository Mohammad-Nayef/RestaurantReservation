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

        public async Task<int> CreateAsync(OrderItem newOrderItem)
        {
            var orderItem = await _context.OrderItems.AddAsync(newOrderItem);
            await _context.SaveChangesAsync();
            return orderItem.Entity.Id;
        }

        public async Task<OrderItem> GetAsync(int orderItemId)
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

        public async Task<List<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task UpdateAsync(OrderItem updatedOrderItem)
        {
            _context.OrderItems.Update(updatedOrderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderItemId)
        {
            var orderItem = await GetAsync(orderItemId);
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}
