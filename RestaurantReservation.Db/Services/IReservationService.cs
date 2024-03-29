﻿using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Services
{
    public interface IReservationService
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
        /// <param name="pageNumber">Number of the needed page.</param>
        /// <param name="pageSize">Number of elements the page contains.</param>
        /// <returns></returns>
        Task<List<Reservation>> GetAllAsync(int pageNumber, int pageSize);

        Task UpdateAsync(Reservation updatedReservation);

        /// <exception cref="KeyNotFoundException"></exception>
        Task DeleteAsync(int reservationId);

        Task<List<Reservation>> GetReservationsByCustomerAsync(
            int customerId, int pageNumber, int pageSize);

        Task<int> GetReservationsCountAsync();

        Task<int> GetReservationsByCustomerCountAsync(int customerId);

        Task<bool> ReservationExistsAsync(int reservationId);

        Task<List<Order>> ListOrdersAndMenuItemsByReservationAsync(
            int reservationId, int pageNumber, int pageSize);

        Task<List<MenuItem>> ListOrderedMenuItemsAsync(
            int reservationId,
            int pageNumber,
            int pageSize);

        Task<int> GetOrdersByReservationCountAsync(int reservationId);

        Task<int> GetMenuItemsByReservationCountAsync(int reservationId);
    }
}