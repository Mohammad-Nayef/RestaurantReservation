using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class TableService : ITableService
    {
        private RestaurantReservationDbContext _context;
        private TableRepository tablesRepository;

        public TableService(RestaurantReservationDbContext context)
        {
            _context = context;
            tablesRepository = new(_context);
        }

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
