using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

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

        public async Task<bool> ReservationExistsAsync(int reservationId)
        {
            return await _context.Reservations
                .AnyAsync(reservation => reservation.Id == reservationId);
        }

        public async Task<int> GetReservationsCountAsync()
        {
            if (_context.Reservations.TryGetNonEnumeratedCount(out var count))
                return count;

            return await _context.Reservations.CountAsync();
        }
    }
}