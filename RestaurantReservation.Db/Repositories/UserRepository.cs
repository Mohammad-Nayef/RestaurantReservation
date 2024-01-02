using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public class UserRepository : IUserRepository
    {
        private RestaurantReservationDbContext _context;

        public UserRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<int> CreateAsync(User newUser)
        {
            if (newUser.Id < 0)
            {
                throw new Exception("Id property can't be negative.");
            }
            if (await UserExistsAsync(newUser.Id))
            {
                throw new Exception($"The user Id {newUser.Id} already exists.");
            }

            var user = await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return user.Entity.Id;
        }

        public async Task<User> GetAsync(int userId)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(user => user.Id == userId);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID = {userId} does not exist.");
            }

            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> GetAllAsync(int skipCount, int takeCount)
        {
            return await _context.Users
                .OrderBy(user => user.FirstName)
                .ThenBy(user => user.LastName)
                .Skip(skipCount)
                .Take(takeCount)
                .ToListAsync();
        }

        public async Task UpdateAsync(User updatedUser)
        {
            if (!(await UserExistsAsync(updatedUser.Id)))
            {
                throw new KeyNotFoundException(
                    $"User with ID = {updatedUser.Id} does not exist.");
            }

            _context.Users.Update(updatedUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            var user = await GetAsync(userId);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserExistsAsync(int userId) =>
            await _context.Users.AnyAsync(user => user.Id == userId);

        public async Task<int> GetUsersCountAsync()
        {
            if (_context.Users.TryGetNonEnumeratedCount(out var fastCount))
                return fastCount;

            return await _context.Users.CountAsync();
        }

        public async Task<bool> ContainsUsernameAsync(string username) =>
            await _context.Users.AnyAsync(user => user.Username == username);

        public async Task<User> GetUserByUsernameAsync(string username) =>
            await _context.Users.SingleOrDefaultAsync(user => user.Username == username);
    }
}
