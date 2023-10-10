using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    [Table("Restaurants")]
    public class RestaurantDTO
    {
        [Column("restaurant_id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("opening_hours")]
        public string OpeningHours { get; set; }

        public List<ReservationDTO> Reservations { get; set; } = new List<ReservationDTO>();

        public List<TableDTO> Tables { get; set; } = new List<TableDTO>();

        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();

        public List<MenuItemDTO> MenuItems { get; set; } = new List<MenuItemDTO>();
    }
}
