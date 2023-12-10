using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.Models
{
    public class UserLoginDTO
    {
        /// <summary>
        /// Only letters and underscores are allowed with length of 1 to 50 characters.
        /// </summary>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// Length must be from 8 to 50 characters.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
