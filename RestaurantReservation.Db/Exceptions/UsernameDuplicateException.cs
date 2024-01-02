namespace RestaurantReservation.Db.Exceptions
{
    public class UsernameDuplicateException : Exception
    {
        public UsernameDuplicateException() : base("The username already exists.")
        {
        }

        public UsernameDuplicateException(string username) : base($"The username '{username}'" +
            $" already exists.") 
        {

        }
    }
}
