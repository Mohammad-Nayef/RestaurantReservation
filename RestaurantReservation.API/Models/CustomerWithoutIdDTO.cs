namespace RestaurantReservation.API.Models
{
    /// <summary>
    /// A customer without Id property for creating a new one.
    /// </summary>
    public class CustomerWithoutIdDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
