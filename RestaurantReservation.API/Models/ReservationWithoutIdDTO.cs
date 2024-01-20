using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.Models
{
    public class ReservationWithoutIdDTO
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public int TableId { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        [Required]
        public int PartySize { get; set; }
    }
}
