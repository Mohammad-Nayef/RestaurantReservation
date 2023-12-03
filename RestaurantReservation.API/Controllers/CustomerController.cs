using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Entities;
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
        /// <response code="200">Returns list of the requested customers with pagination metadata in the headers.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<CustomerDTO>), StatusCodes.Status200OK)]
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

        /// <summary>
        /// Gets a customer by his Id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Returns the requested customer.</response>
        /// <response code="404">The customer with the given Id doesn't exist.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CustomerDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            Customer customer;

            try
            {
                customer = await _customerService.GetAsync(id);
            }
            catch (KeyNotFoundException) 
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CustomerDTO>(customer));
        }
    }
}
