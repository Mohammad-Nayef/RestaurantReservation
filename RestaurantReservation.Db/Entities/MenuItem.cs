namespace RestaurantReservation.Db.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }

        public int? RestaurantId { get; set; }

        public Restaurant? Restaurant { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public override string ToString()
        {
            return $"Id: {Id}, RestaurantId: {RestaurantId}, Name: {Name}, " +
                $"Description: {Description}, Price: {Price}";
        }
    }
}
