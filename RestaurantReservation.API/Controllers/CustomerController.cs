using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly int _pageSizeLimit;

        public CustomerController(
            ICustomerService customerService,
            IConfiguration config,
            IMapper mapper)
        {
            _customerService = customerService ?? 
                throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _pageSizeLimit = config.GetValue<int>("PageSizeLimit");
        }

        /// <summary>
        /// Gets customers partitioned into pages.
        /// </summary>
        /// <param name="pageNumber">Number of the page that contains the needed customers.</param>
        /// <param name="pageSize">The size of the needed page.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > _pageSizeLimit)
                pageSize = _pageSizeLimit;

            var customers = await _customerService.GetAllAsync(pageNumber, pageSize);
            AddPaginationMetadataToHeaders(pageNumber, pageSize);

            return Ok(_mapper.Map<List<CustomerDTO>>(customers));
        }

        private void AddPaginationMetadataToHeaders(int pageNumber, int pageSize)
        {
            var paginationMetadata = new PaginationMetadataDTO(
                _customerService.GetCustomersCount(), pageSize, pageNumber);
            var jsonPaginationMetadata = JsonSerializer.Serialize(paginationMetadata);

            Response.Headers.Add("X-Pagination", jsonPaginationMetadata);
        }
    }
}
