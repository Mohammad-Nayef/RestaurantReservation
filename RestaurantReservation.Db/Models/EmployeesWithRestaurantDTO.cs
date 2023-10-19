namespace RestaurantReservation.Db.Models
{
    public partial class EmployeesWithRestaurantDTO
    {
        public int EmployeeId { get; set; }

        public string? EmployeeFirstName { get; set; }

        public string? EmployeeLastName { get; set; }

        public string? EmployeePosition { get; set; }

        public int? RestaurantId { get; set; }

        public string? RestaurantName { get; set; }

        public string? RestaurantAddress { get; set; }

        public string? RestaurantPhoneNumber { get; set; }

        public string? RestaurantOpeningHours { get; set; }

        public override string ToString()
        {
            return $"Id: {EmployeeId}, EmployeeFirstName: {EmployeeFirstName}, " +
                $"EmployeeLastName: {EmployeeLastName}, EmployeePosition: {EmployeePosition}, " +
                $"RestaurantId: {RestaurantId}, RestaurantName: {RestaurantName}, " +
                $"RestaurantAddress: {RestaurantAddress}, RestaurantPhoneNumber: " +
                $"{RestaurantPhoneNumber}, RestaurantOpeningHours: {RestaurantOpeningHours}";
        }
    }
}