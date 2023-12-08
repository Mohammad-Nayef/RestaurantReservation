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
        Task<int> CreateAsync(Reservation newReservation);

        /// <exception cref="KeyNotFoundException"></exception>
        Task<Reservation> GetAsync(int reservationId);

        Task<List<Reservation>> GetAllAsync();

        /// <summary>
        /// Gets a page of the collection.
        /// </summary>
        /// <param name="skipCount">Number of values to skip from the beginning of the collection.</param>
        /// <param name="takeCount">Number of values to take after the skipped values.</param>
        Task<List<Reservation>> GetAllAsync(int skipCount, int takeCount);

        Task UpdateAsync(Reservation updatedReservation);

        /// <exception cref="KeyNotFoundException"></exception>
        Task DeleteAsync(int reservationId);

        Task<int> GetReservationsCountAsync();

        Task<bool> ReservationExistsAsync(int reservationId);

        Task<List<Order>> ListOrdersAndMenuItemsByReservationAsync(
            int reservationId,
            int skipCount,
            int takeCount);

        Task<List<MenuItem>> ListOrderedMenuItemsAsync(
            int reservationId,
            int skipCount,
            int takeCount);

        Task<int> GetOrdersByReservationCountAsync(int reservationId);

        Task<List<Reservation>> GetReservationsByCustomerAsync(
            int customerId, 
            int skipCount, 
            int takeCount);

        Task<int> GetReservationsByCustomerCountAsync(int customerId);

        Task<int> GetMenuItemsByReservationCountAsync(int reservationId);
    }
}
