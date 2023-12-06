using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API.Extensions;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IValidator<ReservationWithoutIdDTO> _validator;
        private readonly int _pageSizeLimit;

        public ReservationController(
            IReservationService reservationService,
            IConfiguration config,
            IMapper mapper,
            ICustomerService customerService,
            IOrderService orderService,
            IValidator<ReservationWithoutIdDTO> validator)
        {
            _reservationService = reservationService ??
                throw new ArgumentNullException(nameof(reservationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _pageSizeLimit = config.GetValue<int>("PageSizeLimit");
            _customerService = customerService ?? 
                throw new ArgumentNullException(nameof(customerService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Gets reservations partitioned into pages.
        /// </summary>
        /// <param name="pageNumber">Number of the page that contains the needed reservations.</param>
        /// <param name="pageSize">The size of the needed page.</param>
        /// <response code="200">Returns list of the requested reservations with pagination metadata in the headers.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<ReservationDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReservationsAsync(
            int pageNumber = 1, 
            int pageSize = 10)
        {
            if (pageSize > _pageSizeLimit)
                pageSize = _pageSizeLimit;

            var reservationsCount = await _reservationService.GetReservationsCountAsync();
            Response.Headers.AddPaginationMetadata(reservationsCount, pageSize, pageNumber);

            var reservations = await _reservationService.GetAllAsync(pageNumber, pageSize);

            return Ok(_mapper.Map<List<ReservationDTO>>(reservations));
        }

        /// <summary>
        /// Gets a reservation by its Id.
        /// </summary>
        /// <param name="reservationId">The Id property of the needed reservation</param>
        /// <response code="200">Returns the requested reservation.</response>
        /// <response code="404">The reservation with the given Id doesn't exist.</response>
        [HttpGet("{reservationId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ReservationDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReservationAsync(int reservationId)
        {
            Reservation reservation;

            try
            {
                reservation = await _reservationService.GetAsync(reservationId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ReservationDTO>(reservation));
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
            if (pageSize > _pageSizeLimit)
                pageSize = _pageSizeLimit;

            if (!await _customerService.CustomerExistsAsync(customerId))
                return NotFound();

            var reservationsCountByCustomer = await _reservationService.
                GetReservationsByCustomerCountAsync(customerId);
            Response.Headers.AddPaginationMetadata(
                reservationsCountByCustomer, pageSize, pageNumber);

            var reservationsByCustomer = await _reservationService.
                GetReservationsByCustomerAsync(customerId);

            return Ok(_mapper.Map<List<ReservationDTO>>(reservationsByCustomer));
        }

        /// <summary>
        /// Create and store a new reservation.
        /// </summary>
        /// <param name="newReservation">Properties of the new reservation.</param>
        /// <response code="201">Returns the reservation with a new Id and its URI is in the headers.</response>
        /// <response code="422">There's an invalid foreign key returned in the response body.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ReservationDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateReservationAsync(
            ReservationWithoutIdDTO newReservation)
        {
            var validationResult = await _validator.ValidateAsync(newReservation);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.GetImportantProperties());

            int newId;

            try
            {
                newId = await _reservationService.
                CreateAsync(_mapper.Map<Reservation>(newReservation));
            }
            catch (DbUpdateException ex)
            {
                return UnprocessableEntity(
                    $"Invalid foreign key: {ex.ExtractForeignKey()}");
            }

            var responseReservation = _mapper.Map<ReservationDTO>(newReservation);
            responseReservation.Id = newId;

            return Created($"api/reservations/{newId}", responseReservation);
        }

        /// <summary>
        /// Update a reservation with a specific Id.
        /// </summary>
        /// <param name="reservationId">The Id of the reservation to update.</param>
        /// <param name="updatedReservation">The reservation with updated value(s).</param>
        /// <response code="404">The reservation with the given Id doesn't exist.</response>
        /// <response code="422">There's an invalid foreign key returned in the response body.</response>
        /// <response code="204">The reservation is updated successfully.</response>
        [HttpPut("{reservationId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateReservationAsync(
            int reservationId,
            ReservationWithoutIdDTO updatedReservation)
        {
            var validationResult = await _validator.ValidateAsync(updatedReservation);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.GetImportantProperties());

            var reservationWithId = _mapper.Map<Reservation>(updatedReservation);
            reservationWithId.Id = reservationId;

            try
            {
                await _reservationService.UpdateAsync(reservationWithId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateException ex)
            {
                return UnprocessableEntity(
                    $"Invalid foreign key: {ex.ExtractForeignKey()}");
            }

            return NoContent();
        }

        /// <summary>
        /// Delete a reservation with a specific Id.
        /// </summary>
        /// <param name="reservationId">The Id of the reservation to delete.</param>
        /// <response code="404">The reservation with the given Id doesn't exist.</response>
        /// <response code="204">The reservation is deleted successfully.</response>
        [HttpDelete("{reservationId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteReservationAsync(int reservationId)
        {
            try
            {
                await _reservationService.DeleteAsync(reservationId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
