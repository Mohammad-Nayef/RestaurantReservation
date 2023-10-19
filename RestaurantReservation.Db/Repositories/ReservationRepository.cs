﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

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

        public async Task<int> CreateAsync(ReservationDTO newReservation)
        {
            var reservation = await _context.Reservations.AddAsync(newReservation);
            await _context.SaveChangesAsync();
            return reservation.Entity.Id;
        }

        public async Task<ReservationDTO> GetAsync(int reservationId)
        {
            var reservation = await _context.Reservations
                .SingleOrDefaultAsync(r => r.Id == reservationId);

            if (reservation != null)
            {
                return reservation;
            }
            else
            {
                throw new KeyNotFoundException($"Reservation with ID = {reservationId} does not exist.");
            }
        }

        public async Task<List<ReservationDTO>> GetAllAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task UpdateAsync(ReservationDTO updatedReservation)
        {
            _context.Reservations.Update(updatedReservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int reservationId)
        {
            var reservation = await GetAsync(reservationId);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }
}