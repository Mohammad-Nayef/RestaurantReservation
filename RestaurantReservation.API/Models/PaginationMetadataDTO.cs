namespace RestaurantReservation.API.Models
{
    public class PaginationMetadataDTO
    {
        public int TotalItemsCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPagesCount => (int)Math.Ceiling((double)TotalItemsCount / PageSize);

        public PaginationMetadataDTO(int totalItemCount, int pageSize, int currentPage)
        {
            TotalItemsCount = totalItemCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
        }
    }
}
