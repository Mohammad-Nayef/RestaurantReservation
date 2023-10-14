namespace RestaurantReservation.Db.Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public int? RestaurantId { get; set; }

        public RestaurantDTO Restaurant { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}
