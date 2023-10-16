﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<OrderDTO> DbSet => _context.Orders;

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(OrderDTO newOrder)
        {
            var order = await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return order.Entity.Id;
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<OrderDTO> GetAsync(int orderId)
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

        public async Task<List<OrderDTO>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task UpdateAsync(OrderDTO updatedOrder)
        {
            _context.Orders.Update(updatedOrder);
            await _context.SaveChangesAsync();
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task DeleteAsync(int orderId)
        {
            var order = await GetAsync(orderId);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
