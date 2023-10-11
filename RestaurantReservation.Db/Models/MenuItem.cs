using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
