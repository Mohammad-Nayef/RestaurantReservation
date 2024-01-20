using System.Text.Json.Serialization;

namespace RestaurantReservation.Db.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int? ReservationId { get; set; }

        [JsonIgnore]
        public Reservation? Reservation { get; set; }

        public int? EmployeeId { get; set; }

        [JsonIgnore]
        public Employee? Employee { get; set; }

        public DateTime OrderDate { get; set; }

        public int TotalAmount { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public override string ToString()
        {
            return $"Id: {Id}, ReservationId: {ReservationId}, EmployeeId: {EmployeeId}, " +
                $"OrderDate: {OrderDate}, TotalAmount: {TotalAmount}";
        }
    }
}
