using System.Text.Json.Serialization;

namespace RestaurantReservation.Db.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }
        [JsonIgnore]

        public Order? Order { get; set; }

        public int? MenuItemId { get; set; }

        public MenuItem? MenuItem { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, OrderId: {OrderId}, MenuItemId: {MenuItemId}, " +
                $"Quantity: {Quantity}";
        }
    }
}
