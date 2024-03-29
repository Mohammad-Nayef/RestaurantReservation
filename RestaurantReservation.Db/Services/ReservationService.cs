﻿using RestaurantReservation.Db.Entities;
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

        public async Task<int> CreateAsync(Reservation newReservation) => await _reservationsRepository.CreateAsync(newReservation);

        public async Task<Reservation> GetAsync(int reservationId) =>
            await _reservationsRepository.GetAsync(reservationId);

        public async Task<List<Reservation>> GetAllAsync() =>
            await _reservationsRepository.GetAllAsync();

        public async Task<List<Reservation>> GetAllAsync(int pageNumber, int pageSize) =>
            await _reservationsRepository.GetAllAsync(
                (pageNumber - 1) * pageSize, pageSize);

        public async Task UpdateAsync(Reservation updatedReservation) =>
            await _reservationsRepository.UpdateAsync(updatedReservation);

        public async Task DeleteAsync(int reservationId) =>
            await _reservationsRepository.DeleteAsync(reservationId);

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(
            int customerId, int pageNumber, int pageSize) => 
            await _reservationsRepository.GetReservationsByCustomerAsync(
                customerId, (pageNumber - 1) * pageSize, pageSize);

        public async Task<int> GetReservationsCountAsync() =>
            await _reservationsRepository.GetReservationsCountAsync();

        public async Task<int> GetReservationsByCustomerCountAsync(int customerId) =>
            await _reservationsRepository.GetReservationsByCustomerCountAsync(customerId);

        public async Task<bool> ReservationExistsAsync(int reservationId) =>
            await _reservationsRepository.ReservationExistsAsync(reservationId);

        public async Task<List<Order>> ListOrdersAndMenuItemsByReservationAsync(
            int reservationId, int pageNumber, int pageSize) => 
            await _reservationsRepository.ListOrdersAndMenuItemsByReservationAsync(
                reservationId, (pageNumber - 1) * pageSize, pageSize);

        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(
            int reservationId, int pageNumber, int pageSize) =>
            await _reservationsRepository.ListOrderedMenuItemsAsync(
                reservationId, (pageNumber - 1) * pageSize, pageSize);

        public async Task<int> GetOrdersByReservationCountAsync(int reservationId) =>
            await _reservationsRepository.GetOrdersByReservationCountAsync(reservationId);

        public async Task<int> GetMenuItemsByReservationCountAsync(int reservationId) =>
            await _reservationsRepository.GetMenuItemsByReservationCountAsync(reservationId);
    }
}
