using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.API.Extensions
{
    public static class ForeignKeyExtensions
    {
        public static string ExtractForeignKey(this DbUpdateException ex)
        {
            // FK_{TableName}_{TableOfForeignKey}_{ForeignKey}
            var fkRegex = new Regex("FK_\\w*");
            var errorMessage = ex.InnerException.Message;

            if (!fkRegex.IsMatch(errorMessage))
                return "Unknown Id";

            return fkRegex.Match(errorMessage)
                .Value
                .Split('_')
                .Last();
        }
    }
}
