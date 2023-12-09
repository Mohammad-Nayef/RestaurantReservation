using Microsoft.AspNet.Identity;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class UserService : IUserService
    {
        private readonly RestaurantReservationDbContext _context;
        private readonly PasswordHasher _passwordHasher = new();
        private readonly UserRepository _userRepository;

        public UserService(RestaurantReservationDbContext context)
        {
            _context = context;
            _userRepository = new(_context);
        }

        public async Task<int> CreateAsync(User newUser)
        {
            if (await _userRepository.ContainsUsernameAsync(newUser.Username))
                throw new UsernameDuplicateException(newUser.Username);

            newUser.Password = _passwordHasher.HashPassword(newUser.Password);

            return await _userRepository.CreateAsync(newUser);
        }

        public async Task<User> GetAsync(int userId)
        {
            return await _userRepository.GetAsync(userId);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<List<User>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _userRepository.GetAllAsync(
                (pageNumber - 1) * pageSize, pageSize);
        }

        public async Task UpdateAsync(User updatedUser)
        {
            await _userRepository.UpdateAsync(updatedUser);
        }

        public async Task DeleteAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        public async Task<int> GetUsersCountAsync() =>
            await _userRepository.GetUsersCountAsync();

        public async Task<bool> UserExistsAsync(int userId)
        {
            return await _userRepository.UserExistsAsync(userId);
        }

        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            var storedUser = await _userRepository.GetUserByUsernameAsync(username);

            if (storedUser == null)
                return null;

            var passwordVerificationResult = _passwordHasher.
                VerifyHashedPassword(storedUser.Password, password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
                return null;

            return storedUser;
        }
    }
}
