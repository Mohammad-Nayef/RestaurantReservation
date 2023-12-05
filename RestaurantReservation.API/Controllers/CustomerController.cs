using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Extensions;
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
        public async Task<IActionResult> GetCustomersAsync(int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > _pageSizeLimit)
                pageSize = _pageSizeLimit;

            var customers = await _customerService.GetAllAsync(pageNumber, pageSize);
            var customersCount = await _customerService.GetCustomersCountAsync();

            Response.Headers.AddPaginationMetadata(
                customersCount, pageSize, pageNumber);

            return Ok(_mapper.Map<List<CustomerDTO>>(customers));
        }

        /// <summary>
        /// Gets a customer by his Id.
        /// </summary>
        /// <param name="customerId">The Id property of the needed customer</param>
        /// <response code="200">Returns the requested customer.</response>
        /// <response code="404">The customer with the given Id doesn't exist.</response>
        [HttpGet("{customerId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CustomerDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomerAsync(int customerId)
        {
            Customer customer;

            try
            {
                customer = await _customerService.GetAsync(customerId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CustomerDTO>(customer));
        }

        /// <summary>
        /// Create and store a new customer.
        /// </summary>
        /// <param name="newCustomer">Properties of the new customer.</param>
        /// <response code="201">Returns the customer with a new Id and his URI is in the headers.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomerDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCustomerAsync(CustomerWithoutIdDTO newCustomer)
        {
            var newId = await _customerService.
                CreateAsync(_mapper.Map<Customer>(newCustomer));

            var responseCustomer = _mapper.Map<CustomerDTO>(newCustomer);
            responseCustomer.Id = newId;

            return Created($"api/customers/{newId}", responseCustomer);
        }

        /// <summary>
        /// Update a customer with a specific Id.
        /// </summary>
        /// <param name="customerId">The Id of the customer to update.</param>
        /// <param name="updatedCustomer">The customer with updated value(s).</param>
        /// <response code="404">The customer with the given Id doesn't exist.</response>
        /// <response code="204">The customer is updated successfully.</response>
        [HttpPut("{customerId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCustomerAsync(
            int customerId,
            CustomerWithoutIdDTO updatedCustomer)
        {
            var customerWithId = _mapper.Map<Customer>(updatedCustomer);
            customerWithId.Id = customerId;

            try
            {
                await _customerService.UpdateAsync(customerWithId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Delete a customer with a specific Id.
        /// </summary>
        /// <param name="customerId">The Id of the customer to delete.</param>
        /// <response code="404">The customer with the given Id doesn't exist.</response>
        /// <response code="204">The customer is deleted successfully.</response>
        [HttpDelete("{customerId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCustomerAsync(int customerId)
        {
            try
            {
                await _customerService.DeleteAsync(customerId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
