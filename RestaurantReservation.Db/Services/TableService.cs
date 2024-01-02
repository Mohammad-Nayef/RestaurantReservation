using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class TableService : ITableService
    {
        private RestaurantReservationDbContext _context;
        private TableRepository _tablesRepository;

        public TableService(RestaurantReservationDbContext context)
        {
            _context = context;
            _tablesRepository = new(_context);
        }

        public async Task<int> CreateAsync(Table newTable)
        {
            return await _tablesRepository.CreateAsync(newTable);
        }

        public async Task<Table> GetAsync(int tableId)
        {
            return await _tablesRepository.GetAsync(tableId);
        }

        public async Task<List<Table>> GetAllAsync()
        {
            return await _tablesRepository.GetAllAsync();
        }

        public async Task UpdateAsync(Table updatedTable)
        {
            await _tablesRepository.UpdateAsync(updatedTable);
        }

        public async Task DeleteAsync(int tableId)
        {
            await _tablesRepository.DeleteAsync(tableId);
        }
    }
}
