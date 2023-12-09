using FluentValidation;
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
                .Matches(@"[A-Za-z_]+").WithMessage("Only letters and underscores are allowed.")
                .Length(1, 50);

            RuleFor(user => user.Password)
                .Length(8, 50);
        }
    }
}