using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string OpeningHours { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public List<Table> Tables { get; set; } = new List<Table>();

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
