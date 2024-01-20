using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.Models
{
    public class UserWithoutIdDTO
    {
        /// <summary>
        /// Only letters and spaces are allowed with length of 3 to 30 characters.
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Only letters and spaces are allowed with length of 3 to 30 characters.
        /// </summary>
        [Required]
        public string LastName { get; set; }
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
