using FluentValidation;
using RestaurantReservation.API.Extensions;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Validators
{
    public class EmployeeWithoutIdValidator : AbstractValidator<EmployeeWithoutIdDTO>
    {
        public EmployeeWithoutIdValidator()
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
