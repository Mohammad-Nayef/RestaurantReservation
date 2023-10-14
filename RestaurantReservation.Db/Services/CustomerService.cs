﻿using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class CustomerService
    {
        private RestaurantReservationDbContext _context = new();
        private CustomersRepository customersRepository;

        public CustomerService(RestaurantReservationDbContext context = null)
        {
            _context = context ?? new();
            customersRepository = new(_context);
        }

        ~CustomerService()
        {
            _context.DisposeAsync();
        }

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(CustomerDTO newCustomer)
        {
            return await customersRepository.CreateAsync(newCustomer);
        }

        public async Task<CustomerDTO> GetAsync(int customerId)
        {
            return await customersRepository.GetAsync(customerId);
        }

        public async Task<List<CustomerDTO>> GetAllAsync()
        {
            return await customersRepository.GetAllAsync();
        }

        public async Task UpdateAsync(CustomerDTO updatedCustomer)
        {
            await customersRepository.UpdateAsync(updatedCustomer);
        }

        public async Task DeleteAsync(int customerId)
        {
            await customersRepository.DeleteAsync(customerId);
        }
    }
}