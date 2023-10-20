﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository : ITableRepository
    {
        private RestaurantReservationDbContext _context;

        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<int> CreateAsync(TableDTO newTable)
        {
            if (newTable.Id < 0)
            {
                throw new Exception("Id property can't be negative.");
            }
            else if (await TableExistsAsync(newTable.Id))
            {
                throw new Exception($"The table Id {newTable.Id} already exists.");
            }

            var table = await _context.Tables.AddAsync(newTable);
            await _context.SaveChangesAsync();
            return table.Entity.Id;
        }

        public async Task<TableDTO> GetAsync(int tableId)
        {
            var table = await _context.Tables
                .SingleOrDefaultAsync(t => t.Id == tableId);

            if (table == null)
            {
                throw new KeyNotFoundException($"Table with ID = {tableId} does not exist.");
            }
            else
            {
                return table;
            }
        }

        public async Task<List<TableDTO>> GetAllAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task UpdateAsync(TableDTO updatedTable)
        {
            if (!(await TableExistsAsync(updatedTable.Id)))
            {
                throw new KeyNotFoundException($"Table with ID = {updatedTable.Id} does not exist.");
            }

            _context.Tables.Update(updatedTable);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int tableId)
        {
            var table = await GetAsync(tableId);
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> TableExistsAsync(int tableId)
        {
            return await _context.Tables.FindAsync(tableId) != null;
        }
    }
}
