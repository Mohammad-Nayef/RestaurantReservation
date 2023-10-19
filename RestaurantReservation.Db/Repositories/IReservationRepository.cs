using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IReservationRepository
    {
        /// <returns>The ID of the created object.</returns>
        public Task<int> CreateAsync(ReservationDTO newReservation);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<ReservationDTO> GetAsync(int reservationId);

        public Task<List<ReservationDTO>> GetAllAsync();

        public Task UpdateAsync(ReservationDTO updatedReservation);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int reservationId);
    }
}
