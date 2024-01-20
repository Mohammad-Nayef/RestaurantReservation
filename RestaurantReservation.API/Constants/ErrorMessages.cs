namespace RestaurantReservation.API.Constants
{
    public class ErrorMessages
    {
        public const string InvalidName = 
            "'{PropertyName}' should only contain letters and spaces.";
        public const string InvalidPhoneNumber = "'{PropertyName}' must be a valid phone number.";
        public const string InvalidUsername = 
            "Only letters and underscores are allowed for username.";
        public const string DbUpdateError = 
            "An error occurred while trying to store the new entity.";
    }
}
