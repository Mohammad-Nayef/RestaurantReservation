using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Exceptions;

namespace RestaurantReservation.Db.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Adds the new user to the database.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>The ID of the added user.</returns>
        /// <exception cref="UsernameDuplicateException"></exception>
        Task<int> CreateAsync(User newUser);

        /// <exception cref="KeyNotFoundException"></exception>
        Task<User> GetAsync(int userId);

        Task<List<User>> GetAllAsync();

        /// <summary>
        /// Gets a page of the collection ordered by the name.
        /// </summary>
        /// <param name="pageNumber">Number of the needed page.</param>
        /// <param name="pageSize">Number of elements the page contains.</param>
        /// <returns></returns>
        Task<List<User>> GetAllAsync(int pageNumber, int pageSize);

        /// <exception cref="KeyNotFoundException"></exception>
        Task UpdateAsync(User updatedUser);

        /// <exception cref="KeyNotFoundException"></exception>
        Task DeleteAsync(int userId);

        Task<int> GetUsersCountAsync();

        Task<bool> UserExistsAsync(int userId);

        Task<User> AuthenticateUserAsync(string username, string password);
    }
}
