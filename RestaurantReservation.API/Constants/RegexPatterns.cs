namespace RestaurantReservation.API.Constants
{
    public class RegexPatterns
    {
        public const string Name = @"^[A-Za-z\s]+$";
        public const string PhoneNumber = 
            @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
        public const string Username = @"[A-Za-z_]+";
    }
}
