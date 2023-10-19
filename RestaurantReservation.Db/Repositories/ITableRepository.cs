using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface ITableRepository
    {
        /// <returns>The ID of the created object.</returns>
        public Task<int> CreateAsync(TableDTO newTable);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<TableDTO> GetAsync(int tableId);

        public Task<List<TableDTO>> GetAllAsync();

        public Task UpdateAsync(TableDTO updatedTable);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int tableId);
    }
}
