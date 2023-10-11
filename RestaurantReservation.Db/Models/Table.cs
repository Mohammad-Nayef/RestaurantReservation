namespace RestaurantReservation.Db.Models
{
    public class Table
    {
        public int Id { get; set; }

        public int? RestaurantId { get; set; }

        public int Capacity { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
