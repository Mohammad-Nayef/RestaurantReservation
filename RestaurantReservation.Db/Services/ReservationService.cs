using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class ReservationService : IReservationService
    {
        private RestaurantReservationDbContext _context;
        private ReservationRepository _reservationsRepository;

        public ReservationService(RestaurantReservationDbContext context)
        {
            _context = context;
            _reservationsRepository = new(_context);
        }

        public async Task<int> CreateAsync(Reservation newReservation)
        {
            return await _reservationsRepository.CreateAsync(newReservation);
        }

        public async Task<Reservation> GetAsync(int reservationId)
        {
            return await _reservationsRepository.GetAsync(reservationId);
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _reservationsRepository.GetAllAsync();
        }

        public async Task UpdateAsync(Reservation updatedReservation)
        {
            await _reservationsRepository.UpdateAsync(updatedReservation);
        }

        public async Task DeleteAsync(int reservationId)
        {
            await _reservationsRepository.DeleteAsync(reservationId);
        }

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            var reservations = await GetAllAsync();
            return reservations.Where(reservation => reservation.CustomerId == customerId)
                .ToList();
        }
    }
}
