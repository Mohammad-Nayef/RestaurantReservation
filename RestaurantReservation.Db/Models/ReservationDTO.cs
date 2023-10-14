namespace RestaurantReservation.Db.Models
{
    public class ReservationDTO
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public CustomerDTO? Customer { get; set; }

        public int? RestaurantId { get; set; }

        public RestaurantDTO? Restaurant { get; set; }

        public int? TableId { get; set; }

        public TableDTO? Table { get; set; }

        public DateTime ReservationDate { get; set; }

        public int PartySize { get; set; }

        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}
