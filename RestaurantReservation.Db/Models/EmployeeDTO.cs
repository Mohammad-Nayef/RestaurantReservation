using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    [Table("Employees")]
    public class EmployeeDTO
    {
        [Column("employee_id")]
        public int Id { get; set; }

        [Column("restaurant_id")]
        public int RestaurantId { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("lat_name")]
        public string LastName { get; set; }

        [Column("position")]
        public string Position { get; set; }
    }
}
