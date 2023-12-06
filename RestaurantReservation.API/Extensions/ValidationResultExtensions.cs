using FluentValidation.Results;

namespace RestaurantReservation.API.Extensions
{
    public static class ValidationResultExtensions
    {
        /// <summary>
        /// Returns only the important properties contained in the errors list.
        /// </summary>
        public static object GetImportantProperties(this ValidationResult validationResult)
        {
            return validationResult.Errors.Select(error => new
            {
                error.ErrorMessage,
                error.PropertyName,
                error.AttemptedValue
            });
        }
    }
}
