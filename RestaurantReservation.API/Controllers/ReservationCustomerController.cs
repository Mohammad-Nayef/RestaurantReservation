using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Extensions;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("api/reservations")]
    [ApiController]
    public class ReservationCustomerController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly IValidator<ReservationWithoutIdDTO> _validator;
        private readonly int _pageSizeLimit;

        public ReservationCustomerController(
            IReservationService reservationService,
            IConfiguration config,
            IMapper mapper,
            ICustomerService customerService,
            IValidator<ReservationWithoutIdDTO> validator)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _pageSizeLimit = config.GetValue<int>("PageSizeLimit");
            _customerService = customerService;
            _validator = validator;
        }

        /// <summary>
        /// Gets reservations by a specific customer.
        /// </summary>
        /// <param name="customerId">The Id property of the customer to get his reservations</param>
        /// <param name="pageNumber">Number of the page that contains the needed reservations.</param>
        /// <param name="pageSize">The size of the needed page.</param>
        /// <response code="200">Returns the requested reservations.</response>
        /// <response code="404">The customer with the given Id doesn't exist.</response>
        [HttpGet("customer/{customerId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<ReservationDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReservationsByCustomerAsync(
            int customerId,
            int pageNumber = 1,
            int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
                return BadRequest(
                    $"'{nameof(pageNumber)}' and '{nameof(pageSize)}' must be greater than 0.");

            if (pageSize > _pageSizeLimit)
                pageSize = _pageSizeLimit;

            if (!await _customerService.CustomerExistsAsync(customerId))
                return NotFound();

            var reservationsCountByCustomer = await _reservationService.
                GetReservationsByCustomerCountAsync(customerId);
            Response.Headers.AddPaginationMetadata(
                reservationsCountByCustomer, pageSize, pageNumber);

            var reservationsByCustomer = await _reservationService.
                GetReservationsByCustomerAsync(customerId, pageNumber, pageSize);

            return Ok(_mapper.Map<List<ReservationDTO>>(reservationsByCustomer));
        }
    }
}
