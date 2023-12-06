using FluentValidation;
using RestaurantReservation.API.Extensions;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeWithoutIdDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee.FirstName)
                .ValidateName();

            RuleFor(employee => employee.LastName)
                .ValidateName();

            RuleFor(employee => employee.Position)
                .NotEmpty();
        }
    }
}
