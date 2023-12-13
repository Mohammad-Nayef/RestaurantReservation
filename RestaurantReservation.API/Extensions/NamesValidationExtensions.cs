using FluentValidation;
using RestaurantReservation.API.Constants;

namespace RestaurantReservation.API.Extensions
{
    public static class NamesValidationExtensions
    {
        public const int MinimumNameLength = 3;
        public const int MaximumNameLength = 30;

        /// <summary>
        /// Validate name property using FluentValidation.
        /// </summary>
        public static IRuleBuilderOptions<T, string> ValidateName<T>(
            this IRuleBuilder<T, string> rule)
        {
            return rule
                .Matches(Regex.NamePattern)
                .WithMessage(ErrorMessages.InvalidName)
                .Length(MinimumNameLength, MaximumNameLength);
        }
    }
}
