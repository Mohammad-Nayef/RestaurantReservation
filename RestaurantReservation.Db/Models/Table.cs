using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    [Table("Tables")]
    public class Table
    {
        [Column("table_id")]
        public int Id { get; set; }

        [Column("restaurant_id")]
        public int RestaurantId { get; set; }

        [Column("capacity")]
        public int Capacity { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
