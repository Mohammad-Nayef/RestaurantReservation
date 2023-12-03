using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private RestaurantReservationDbContext _context;

        public OrderItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<int> CreateAsync(OrderItem newOrderItem)
        {
            if (newOrderItem.Id < 0)
            {
                throw new Exception("Id property can't be negative.");
            }
            if (await OrderItemExistsAsync(newOrderItem.Id))
            {
                throw new Exception($"The order item Id {newOrderItem.Id} already exists.");
            }

            var orderItem = await _context.OrderItems.AddAsync(newOrderItem);
            await _context.SaveChangesAsync();
            return orderItem.Entity.Id;
        }

        public async Task<OrderItem> GetAsync(int orderItemId)
        {
            var orderItem = await _context.OrderItems
                .SingleOrDefaultAsync(item => item.Id == orderItemId);

            if (orderItem == null)
            {
                throw new KeyNotFoundException($"Order item with ID = {orderItemId} does not exist.");
            }
            
            return orderItem;
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task UpdateAsync(OrderItem updatedOrderItem)
        {
            if (!(await OrderItemExistsAsync(updatedOrderItem.Id)))
            {
                throw new KeyNotFoundException($"OrderItem with ID = {updatedOrderItem.Id} does not exist.");
            }

            _context.OrderItems.Update(updatedOrderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderItemId)
        {
            var orderItem = await GetAsync(orderItemId);
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> OrderItemExistsAsync(int orderItemId)
        {
            return await _context.OrderItems.AnyAsync(orderItem =>  orderItem.Id == orderItemId);
        }
    }
}
