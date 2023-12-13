using FluentValidation;
using RestaurantReservation.API.Constants;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLoginDTO>
    {
        public UserLoginValidator()
        {
            RuleFor(user => user.Username)
                .Matches(Regex.Username)
                .WithMessage(ErrorMessages.InvalidUsername)
                .Length(Username.MinimumLength, Username.MaximumLength);

            RuleFor(user => user.Password)
                .Length(Password.MinimumLength, Password.MaximumLength);
        }
    }
}
