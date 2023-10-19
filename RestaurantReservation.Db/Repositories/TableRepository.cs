using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository
    {
        private RestaurantReservationDbContext _context;

        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public DbSet<TableDTO> DbSet => _context.Tables;

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(TableDTO newTable)
        {
            var table = await _context.Tables.AddAsync(newTable);
            await _context.SaveChangesAsync();
            return table.Entity.Id;
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<TableDTO> GetAsync(int tableId)
        {
            var table = await _context.Tables
                .SingleOrDefaultAsync(t => t.Id == tableId);

            if (table != null)
            {
                return table;
            }
            else
            {
                throw new KeyNotFoundException($"Table with ID = {tableId} does not exist.");
            }
        }

        public async Task<List<TableDTO>> GetAllAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task UpdateAsync(TableDTO updatedTable)
        {
            _context.Tables.Update(updatedTable);
            await _context.SaveChangesAsync();
        }

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task DeleteAsync(int tableId)
        {
            var table = await GetAsync(tableId);
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }
    }
}
