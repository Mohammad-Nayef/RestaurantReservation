using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    [Table("Orders")]
    public class OrderDTO
    {
        [Column("order_id")]
        public int Id { get; set; }

        [Column("reservation_id")]
        public int ReservationId { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Column("total_amount")]
        public int TotalAmount { get; set; }
    }
}
