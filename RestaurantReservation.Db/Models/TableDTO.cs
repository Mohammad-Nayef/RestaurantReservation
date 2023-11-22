namespace RestaurantReservation.Db.Models
{
    public class TableDTO
    {
        public int Id { get; set; }

        public int? RestaurantId { get; set; }

        public RestaurantDTO? Restaurant { get; set; }

        public int Capacity { get; set; }

        public List<ReservationDTO> Reservations { get; set; } = new List<ReservationDTO>();

        public override string ToString()
        {
            return $"Id: {Id}, RestaurantId: {RestaurantId}, Capacity: {Capacity}";
        }
    }
}
