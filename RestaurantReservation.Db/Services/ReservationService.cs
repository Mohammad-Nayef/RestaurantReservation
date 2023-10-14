using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class ReservationService
    {
        private RestaurantReservationDbContext _context = new();
        private ReservationsRepository reservationsRepository;

        public ReservationService(RestaurantReservationDbContext context = null)
        {
            _context = context ?? new();
            reservationsRepository = new(_context);
        }

        ~ReservationService()
        {
            _context.DisposeAsync();
        }

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(ReservationDTO newReservation)
        {
            return await reservationsRepository.CreateAsync(newReservation);
        }

        public async Task<ReservationDTO> GetAsync(int reservationId)
        {
            return await reservationsRepository.GetAsync(reservationId);
        }

        public async Task<List<ReservationDTO>> GetAllAsync()
        {
            return await reservationsRepository.GetAllAsync();
        }

        public async Task UpdateAsync(ReservationDTO updatedReservation)
        {
            await reservationsRepository.UpdateAsync(updatedReservation);
        }

        public async Task DeleteAsync(int reservationId)
        {
            await reservationsRepository.DeleteAsync(reservationId);
        }

        public async Task<List<ReservationDTO>> GetReservationsByCustomerAsync(int customerId)
        {
            var reservations = await GetAllAsync();
            return reservations.Where(reservation => reservation.CustomerId == customerId)
                .ToList();
        }
    }
}
