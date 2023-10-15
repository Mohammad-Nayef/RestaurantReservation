namespace RestaurantReservation.Db.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int? ReservationId { get; set; }

        public ReservationDTO? Reservation { get; set; }

        public int? EmployeeId { get; set; }

        public EmployeeDTO? Employee { get; set; }

        public DateTime OrderDate { get; set; }

        public int TotalAmount { get; set; }

        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
