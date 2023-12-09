using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.Models
{
    public class UserWithoutIdDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
