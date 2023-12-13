using FluentValidation;
using RestaurantReservation.API.Constants;
using RestaurantReservation.API.Extensions;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Validators
{
    public class UserWithoutIdValidator : AbstractValidator<UserWithoutIdDTO>
    {
        public UserWithoutIdValidator()
        {
            RuleFor(user => user.FirstName)
                .ValidateName();

            RuleFor(user => user.LastName)
                .ValidateName();

            RuleFor(user => user.Username)
                .Matches(Regex.Username)
                .WithMessage(ErrorMessages.InvalidUsername)
                .Length(Username.MinimumLength, Username.MaximumLength);

            RuleFor(user => user.Password)
                .Length(Password.MinimumLength, Password.MaximumLength);
        }
    }
}