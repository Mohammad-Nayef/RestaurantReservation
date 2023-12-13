namespace RestaurantReservation.API.Constants
{
    public class Regex
    {
        public const string NamePattern = @"^[A-Za-z\s]+$";
        public const string PhoneNumberPattern = 
            @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
        public const string Username = @"[A-Za-z_]+";
    }
}
