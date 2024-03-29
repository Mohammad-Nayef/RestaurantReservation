﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private RestaurantReservationDbContext _context;

        public ReservationRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<int> CreateAsync(Reservation newReservation)
        {
            if (newReservation.Id < 0)
            {
                throw new Exception("Id property can't be negative.");
            }
            if (await ReservationExistsAsync(newReservation.Id))
            {
                throw new Exception($"The reservation Id {newReservation.Id} already exists.");
            }

            var reservation = await _context.Reservations.AddAsync(newReservation);
            await _context.SaveChangesAsync();
            return reservation.Entity.Id;
        }

        public async Task<Reservation> GetAsync(int reservationId)
        {
            var reservation = await _context.Reservations
                .SingleOrDefaultAsync(r => r.Id == reservationId);

            if (reservation == null)
            {
                throw new KeyNotFoundException($"Reservation with ID = {reservationId} does not exist.");
            }
            
            return reservation;
        }

        public async Task<List<Reservation>> GetAllAsync() =>
            await _context.Reservations.ToListAsync();

        public async Task<List<Reservation>> GetAllAsync(int skipCount, int takeCount)
        {
            return await _context.Reservations
                .Skip(skipCount)
                .Take(takeCount)
                .ToListAsync();
        }

        public async Task UpdateAsync(Reservation updatedReservation)
        {
            if (!(await ReservationExistsAsync(updatedReservation.Id)))
            {
                throw new KeyNotFoundException($"Reservation with ID = {updatedReservation.Id} does not exist.");
            }

            _context.Reservations.Update(updatedReservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int reservationId)
        {
            var reservation = await GetAsync(reservationId);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ReservationExistsAsync(int reservationId) =>
            await _context.Reservations
                .AnyAsync(reservation => reservation.Id == reservationId);

        public async Task<int> GetReservationsCountAsync()
        {
            if (_context.Reservations.TryGetNonEnumeratedCount(out var count))
                return count;

            return await _context.Reservations.CountAsync();
        }

        public async Task<List<Order>> ListOrdersAndMenuItemsByReservationAsync(
            int reservationId,
            int skipCount, 
            int takeCount)
        {
            return await _context.Reservations
                .Where(reservation => reservation.Id == reservationId)
                .SelectMany(reservation => reservation.Orders)
                .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.MenuItem)
                .Skip(skipCount)
                .Take(takeCount)
                .ToListAsync();
        }

        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(
            int reservationId,
            int skipCount,
            int takeCount)
        {
            return await _context.Reservations
                .Where(reservation => reservation.Id == reservationId)
                .SelectMany(reservation => reservation.Orders)
                .SelectMany(order => order.OrderItems)
                .Select(orderItem => orderItem.MenuItem)
                .Skip(skipCount)
                .Take(takeCount)
                .ToListAsync();
        }

        public async Task<int> GetOrdersByReservationCountAsync(int reservationId)
        {
            var orders = _context.Orders
                .Where(order => order.ReservationId == reservationId);

            if (orders.TryGetNonEnumeratedCount(out var fastCount)) 
                return fastCount;

            return await orders.CountAsync();
        }

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(
            int customerId,
            int skipCount,
            int takeCount)
        {
            return await _context.Reservations
                .Where(reservation => reservation.CustomerId == customerId)
                .Skip(skipCount)
                .Take(takeCount)
                .ToListAsync();
        }

        public async Task<int> GetReservationsByCustomerCountAsync(int customerId)
        {
            var reservations = _context.Reservations
                .Where(reservation => reservation.CustomerId == customerId);

            if (reservations.TryGetNonEnumeratedCount(out int fastCount))
                return fastCount;

            return await reservations.CountAsync();
        }

        public async Task<int> GetMenuItemsByReservationCountAsync(int reservationId)
        {
            var menuItems = _context.Reservations
                .Where(reservation => reservation.Id == reservationId)
                .SelectMany(reservation => reservation.Orders)
                .SelectMany(order => order.OrderItems)
                .Select(orderItem => orderItem.MenuItem);

            if (menuItems.TryGetNonEnumeratedCount(out int fastCount))
                return fastCount;

            return  await menuItems.CountAsync();
        }
    }
}