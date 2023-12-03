using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public interface ITableRepository
    {
        /// <summary>
        /// Adds a new table to the database.
        /// </summary>
        /// <param name="newTable"></param>
        /// <returns>The ID of the added table.</returns>
        public Task<int> CreateAsync(Table newTable);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task<Table> GetAsync(int tableId);

        public Task<List<Table>> GetAllAsync();

        public Task UpdateAsync(Table updatedTable);

        /// <exception cref="KeyNotFoundException"></exception>
        public Task DeleteAsync(int tableId);
    }
}
