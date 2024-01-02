namespace RestaurantReservation.Db.Entities
{
    public class Table
    {
        public int Id { get; set; }

        public int? RestaurantId { get; set; }

        public Restaurant? Restaurant { get; set; }

        public int Capacity { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public override string ToString()
        {
            return $"Id: {Id}, RestaurantId: {RestaurantId}, Capacity: {Capacity}";
        }
    }
}
