using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.Models
{
    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
