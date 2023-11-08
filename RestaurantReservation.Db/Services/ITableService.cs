using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Services
{
    public interface ITableService
    {
        /// <summary>
        /// Adds a new table to the database.
        /// </summary>
        /// <param name="newTable"></param>
        /// <returns>The ID of the added table.</returns>
        public Task<int> CreateAsync(TableDTO newTable);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<TableDTO> GetAsync(int tableId);

        public Task<List<TableDTO>> GetAllAsync();
        public Task UpdateAsync(TableDTO updatedTable);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int tableId);
    }
}