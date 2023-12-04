using RestaurantReservation.API.Models;
using System.Text.Json;

namespace RestaurantReservation.API.Extensions
{
    public static class ResponseHeadersExtensions
    {
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
