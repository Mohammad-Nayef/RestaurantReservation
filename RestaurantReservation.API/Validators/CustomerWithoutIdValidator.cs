using FluentValidation;
using RestaurantReservation.API.Models;
using RestaurantReservation.API.Extensions;

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
                .Matches(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$");
        }
    }
}
