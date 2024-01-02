using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Adds the new user to the database.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>The ID of the added user.</returns>
        Task<int> CreateAsync(User newUser);

        /// <exception cref="KeyNotFoundException"></exception>
        Task<User> GetAsync(int userId);

        Task<List<User>> GetAllAsync();

        /// <summary>
        /// Gets a page of the collection ordered by the name.
        /// </summary>
        /// <param name="skipCount">Number of values to skip from the beginning of the collection.</param>
        /// <param name="takeCount">Number of values to take after the skipped values.</param>
        Task<List<User>> GetAllAsync(int skipCount, int takeCount);

        /// <exception cref="KeyNotFoundException"></exception>
        Task UpdateAsync(User updatedUser);

        /// <exception cref="KeyNotFoundException"></exception>
        Task DeleteAsync(int userId);

        Task<int> GetUsersCountAsync();

        Task<User> GetUserByUsernameAsync(string username);
    }
}