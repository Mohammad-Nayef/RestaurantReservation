using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public interface IReservationRepository
    {
        /// <summary>
        /// Adds a new reservation to the database.
        /// </summary>
        /// <param name="newReservation"></param>
        /// <returns>The ID of the added reservation.</returns>
        public Task<int> CreateAsync(Reservation newReservation);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<Reservation> GetAsync(int reservationId);

        public Task<List<Reservation>> GetAllAsync();

        public Task UpdateAsync(Reservation updatedReservation);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int reservationId);
    }
}
