using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    [Table("Tables")]
    public class TableDTO
    {
        [Column("table_id")]
        public int TableId { get; set; }

        [Column("restaurant_id")]
        public int RestaurantId { get; set; }

        [Column("capacity")]
        public int Capacity { get; set; }
    }
}
