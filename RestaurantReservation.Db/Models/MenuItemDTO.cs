namespace RestaurantReservation.Db.Models
{
    public class MenuItemDTO
    {
        public int Id { get; set; }

        public int? RestaurantId { get; set; }

        public RestaurantDTO Restaurant { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
