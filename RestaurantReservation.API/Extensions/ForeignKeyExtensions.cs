using System.Text.RegularExpressions;

namespace RestaurantReservation.API.Extensions
{
    public static class ForeignKeyExtensions
    {
        public static string ExtractForeignKey(this string errorMessage)
        {
            var fkRegex = new Regex("FK_\\w*");

            if (!fkRegex.IsMatch(errorMessage))
                return "Unknown Id";

            // FK_{TableName}_{TableOfForeignKey}_{ForeignKey}
            return fkRegex.Match(errorMessage)
                .Value
                .Split('_')
                .Last();
        }
    }
}
