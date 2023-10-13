using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class OrdersRepository
    {
        private RestaurantReservationDbContext _context;

        public OrdersRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<int> CreateAsync(Order newOrder)
        {
            var order = await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return order.Entity.Id;
        }

        public async Task<Order> GetAsync(int orderId)
        {
            var order = await _context.Orders
                .SingleOrDefaultAsync(o => o.Id == orderId);

            if (order != null)
            {
                return order;
            }
            else
            {
                throw new KeyNotFoundException($"Order with ID = {orderId} does not exist.");
            }
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task UpdateAsync(Order updatedOrder)
        {
            _context.Orders.Update(updatedOrder);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderId)
        {
            var order = await GetAsync(orderId);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
