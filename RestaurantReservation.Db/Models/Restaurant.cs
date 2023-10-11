using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    [Table("Restaurants")]
    public class Restaurant
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

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public List<Table> Tables { get; set; } = new List<Table>();

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
