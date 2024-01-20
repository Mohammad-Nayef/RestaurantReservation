using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Services
{
    /// <summary>
    /// Responsible for dealing with web tokens for authorizing requests.
    /// </summary>
    public interface ITokenGenerator
    {
        /// <summary>
        /// Generates a web token based on the user.
        /// </summary>
        /// <returns>String value of the token.</returns>
        string GenerateToken(UserWithoutPasswordDTO user);
    }
}