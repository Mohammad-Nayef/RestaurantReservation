using FluentValidation.Results;
using RestaurantReservation.API.Models;

namespace RestaurantReservation.API.Extensions
{
    public static class ValidationResultExtensions
    {
        /// <summary>
        /// Returns only the important properties contained in the errors list.
        /// </summary>
        public static List<ValidationResultDTO> GetImportantProperties(
            this ValidationResult validationResult)
        {
            return validationResult.Errors.Select(error => new ValidationResultDTO
            {
                ErrorMessage = error.ErrorMessage,
                PropertyName = error.PropertyName,
                AttemptedValue = (string)error.AttemptedValue
            }).ToList();
        }
    }
}
