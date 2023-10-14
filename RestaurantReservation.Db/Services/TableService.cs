using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class TableService
    {
        private RestaurantReservationDbContext _context = new();
        private TablesRepository tablesRepository;

        public TableService(RestaurantReservationDbContext context = null)
        {
            _context = context ?? new();
            tablesRepository = new(_context);
        }

        ~TableService()
        {
            _context.DisposeAsync();
        }

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(TableDTO newTable)
        {
            return await tablesRepository.CreateAsync(newTable);
        }

        public async Task<TableDTO> GetAsync(int tableId)
        {
            return await tablesRepository.GetAsync(tableId);
        }

        public async Task<List<TableDTO>> GetAllAsync()
        {
            return await tablesRepository.GetAllAsync();
        }

        public async Task UpdateAsync(TableDTO updatedTable)
        {
            await tablesRepository.UpdateAsync(updatedTable);
        }

        public async Task DeleteAsync(int tableId)
        {
            await tablesRepository.DeleteAsync(tableId);
        }
    }
}
