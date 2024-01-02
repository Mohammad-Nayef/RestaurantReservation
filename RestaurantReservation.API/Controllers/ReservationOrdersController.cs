using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Extensions;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("api/reservations")]
    [ApiController]
    public class ReservationOrdersController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly int _pageSizeLimit;

        public ReservationOrdersController(
            IReservationService reservationService,
            IConfiguration config)
        {
            _reservationService = reservationService;
            _pageSizeLimit = config.GetValue<int>("PageSizeLimit");
        }

        /// <summary>
        /// List orders and menu items for a reservation.
        /// </summary>
        /// <param name="reservationId">The Id of the needed reservation</param>
        /// <param name="pageNumber">Number of the page that contains the needed orders.</param>
        /// <param name="pageSize">The size of the needed page.</param>
        /// <response code="200">Returns the requested orders.</response>
        /// <response code="404">The reservation with the given Id doesn't exist.</response>
        [HttpGet("{reservationId}/orders")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<Order>), StatusCodes.Status200OK)]
        public async Task<IActionResult> OrdersAndMenuItemsByReservation(
            int reservationId,
            int pageNumber = 1,
            int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
                return BadRequest(
                    $"'{nameof(pageNumber)}' and '{nameof(pageSize)}' must be greater than 0.");

            if (pageSize > _pageSizeLimit)
                pageSize = _pageSizeLimit;

            if (!await _reservationService.ReservationExistsAsync(reservationId))
                return NotFound();

            var ordersOfReservationCount = await _reservationService.
                GetOrdersByReservationCountAsync(reservationId);
            Response.Headers.AddPaginationMetadata(
                ordersOfReservationCount, pageSize, pageNumber);

            var ordersAndMenuItems = await _reservationService.
                ListOrdersAndMenuItemsByReservationAsync(reservationId, pageNumber, pageSize);

            return Ok(ordersAndMenuItems);
        }

        /// <summary>
        /// List ordered menu items for a reservation.
        /// </summary>
        /// <param name="reservationId">The Id of the needed reservation</param>
        /// <param name="pageNumber">Number of the page that contains the needed menu items.</param>
        /// <param name="pageSize">The size of the needed page.</param>
        /// <response code="200">Returns the requested menu items.</response>
        /// <response code="404">The reservation with the given Id doesn't exist.</response>
        [HttpGet("{reservationId}/menu-items")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<MenuItem>), StatusCodes.Status200OK)]
        public async Task<IActionResult> OrderedMenuItemsByReservation(
            int reservationId,
            int pageNumber = 1,
            int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
                return BadRequest(
                    $"'{nameof(pageNumber)}' and '{nameof(pageSize)}' must be greater than 0.");

            if (pageSize > _pageSizeLimit)
                pageSize = _pageSizeLimit;

            if (!await _reservationService.ReservationExistsAsync(reservationId))
                return NotFound();

            var menuItemsOfReservationCount = await _reservationService
                .GetMenuItemsByReservationCountAsync(reservationId);
            Response.Headers.AddPaginationMetadata(
                menuItemsOfReservationCount, pageSize, pageNumber);

            var menuItemsOfReservation = await _reservationService
                .ListOrderedMenuItemsAsync(reservationId, pageNumber, pageSize);

            return Ok(menuItemsOfReservation);
        }
    }
}
