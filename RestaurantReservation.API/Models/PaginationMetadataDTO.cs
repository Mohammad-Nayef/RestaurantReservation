namespace RestaurantReservation.API.Models
{
    public class PaginationMetadataDTO
    {
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

        public PaginationMetadataDTO(int totalItemCount, int pageSize, int currentPage)
        {
            TotalItems = totalItemCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
        }
    }
}
