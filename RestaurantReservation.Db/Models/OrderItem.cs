using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    [Table("OrderItems")]
    public class OrderItem
    {
        [Column("order_item_id")]
        public int Id { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("item_id")]
        public int MenuItemId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
