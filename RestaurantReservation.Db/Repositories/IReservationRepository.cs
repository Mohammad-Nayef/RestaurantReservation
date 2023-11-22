using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IReservationRepository
    {
        /// <summary>
        /// Adds a new reservation to the database.
        /// </summary>
        /// <param name="newReservation"></param>
        /// <returns>The ID of the added reservation.</returns>
        public Task<int> CreateAsync(ReservationDTO newReservation);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<ReservationDTO> GetAsync(int reservationId);

        public Task<List<ReservationDTO>> GetAllAsync();

        public Task UpdateAsync(ReservationDTO updatedReservation);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int reservationId);
    }
}
