namespace RestaurantReservation.Db.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public int? RestaurantId { get; set; }

        public Restaurant? Restaurant { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        public override string ToString()
        {
            return $"Id: {Id}, Name: {FirstName} {LastName}, Restaurant Id: " +
                $"{RestaurantId} Position: {Position}";
        }
    }
}
