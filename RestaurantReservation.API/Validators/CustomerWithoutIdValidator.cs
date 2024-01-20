using FluentValidation;
using RestaurantReservation.API.Models;
using RestaurantReservation.API.Extensions;
using RestaurantReservation.API.Constants;

namespace RestaurantReservation.API.Validators
{
    public class CustomerWithoutIdValidator : AbstractValidator<CustomerWithoutIdDTO>
    {
        public CustomerWithoutIdValidator()
        {
            RuleFor(customer => customer.FirstName)
                .ValidateName();

            RuleFor(customer => customer.LastName)
                .ValidateName();

            RuleFor(customer => customer.Email)
                .EmailAddress();

            RuleFor(customer => customer.PhoneNumber)
                .Matches(RegexPatterns.PhoneNumber)
                .WithMessage(ErrorMessages.InvalidPhoneNumber);
        }
    }
}
