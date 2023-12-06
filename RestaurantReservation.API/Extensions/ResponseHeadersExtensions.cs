using RestaurantReservation.API.Models;
using System.Text.Json;

namespace RestaurantReservation.API.Extensions
{
    public static class ResponseHeadersExtensions
    {
        /// <summary>
        /// Adds the pagination metadata to the headers of the HTTP response.
        /// </summary>
        /// <param name="totalItems">Number of the items.</param>
        /// <param name="pageSize">How many items the page contains.</param>
        /// <param name="pageNumber">Number of the current page.</param>
        public static void AddPaginationMetadata(
            this IHeaderDictionary headers,
            int totalItems,
            int pageSize,
            int pageNumber)
        {
            var paginationMetadata = new PaginationMetadataDTO(totalItems, pageSize, pageNumber);
            var jsonPaginationMetadata = JsonSerializer.Serialize(paginationMetadata);

            headers.Add("X-Pagination", jsonPaginationMetadata);
        }
    }
}
