using FluentValidation;

namespace RestaurantReservation.API.Extensions
{
    public static class NamesValidationExtensions
    {
        /// <summary>
        /// Validate name property using FluentValidation.
        /// </summary>
        public static IRuleBuilderOptions<T, string> ValidateName<T>(
            this IRuleBuilder<T, string> rule)
        {
            return rule
                .Matches(@"^[A-Za-z\s]+$").WithMessage(
                     "'{PropertyName}' should only contain letters and spaces.")
                .Length(3, 30);
        }
    }
}
