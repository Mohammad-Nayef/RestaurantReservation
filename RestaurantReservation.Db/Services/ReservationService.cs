using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class ReservationService
    {
        private RestaurantReservationDbContext _context = new();
        private ReservationsRepository reservationsRepository;

        public ReservationService()
        {
            reservationsRepository = new(_context);
        }

        ~ReservationService()
        {
            _context.DisposeAsync();
        }

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            var reservations = await reservationsRepository.GetAllAsync();
            return reservations.Where(reservation => reservation.CustomerId == customerId)
                .ToList();
        }
    }
}
