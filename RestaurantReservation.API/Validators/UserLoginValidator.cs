using FluentValidation;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLoginDTO>
    {
        public UserLoginValidator()
        {
            RuleFor(user => user.Username)
                .Matches(@"[A-Za-z_]+").WithMessage("Only letters and underscores are allowed.")
                .Length(1, 50);

            RuleFor(user => user.Password)
                .Length(8, 50);
        }
    }
}
