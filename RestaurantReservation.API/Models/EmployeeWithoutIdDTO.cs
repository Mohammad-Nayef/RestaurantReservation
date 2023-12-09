using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.Models
{
    public class EmployeeWithoutIdDTO
    {
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
