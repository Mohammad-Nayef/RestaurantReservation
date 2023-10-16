namespace RestaurantReservation.Db.Models
{
    public partial class EmployeesWithRestaurantDTO
    {
        public int EmployeeId { get; set; }

        public string EmployeeFirstName { get; set; } = null!;

        public string EmployeeLastName { get; set; } = null!;

        public string EmployeePosition { get; set; } = null!;

        public int? RestaurantId { get; set; }

        public string RestaurantName { get; set; } = null!;

        public string RestaurantAddress { get; set; } = null!;

        public string RestaurantPhoneNumber { get; set; } = null!;

        public string RestaurantOpeningHours { get; set; } = null!;
    }
}