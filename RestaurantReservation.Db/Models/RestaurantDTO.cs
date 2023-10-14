namespace RestaurantReservation.Db.Models
{
    public class RestaurantDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string OpeningHours { get; set; }

        public List<ReservationDTO> Reservations { get; set; } = new List<ReservationDTO>();

        public List<TableDTO> Tables { get; set; } = new List<TableDTO>();

        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();

        public List<MenuItemDTO> MenuItems { get; set; } = new List<MenuItemDTO>();
    }
}
