﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private RestaurantReservationDbContext _context;

        public OrderRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<int> CreateAsync(OrderDTO newOrder)
        {
            if (newOrder.Id < 0)
            {
                throw new Exception("Id property can't be negative.");
            }
            if (await OrderExistsAsync(newOrder.Id))
            {
                throw new Exception($"The order Id {newOrder.Id} already exists.");
            }

            var order = await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return order.Entity.Id;
        }

        public async Task<OrderDTO> GetAsync(int orderId)
        {
            var order = await _context.Orders
                .SingleOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID = {orderId} does not exist.");
            }
            
            return order;
        }

        public async Task<List<OrderDTO>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task UpdateAsync(OrderDTO updatedOrder)
        {
            if (!(await OrderExistsAsync(updatedOrder.Id)))
            {
                throw new KeyNotFoundException($"Order with ID = {updatedOrder.Id} does not exist.");
            }

            _context.Orders.Update(updatedOrder);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderId)
        {
            var order = await GetAsync(orderId);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderDTO>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            return await _context.Orders
                .Where(order => order.ReservationId == reservationId)
                .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.MenuItem)
                .ToListAsync();
        }

        private async Task<bool> OrderExistsAsync(int orderId)
        {
            return await _context.Orders.AnyAsync(order => order.Id == orderId);
        }
    }
}
