using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Extensions;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("api")]
    [ApiController]
    public class ManagerController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly int _pageSizeLimit;

        public ManagerController(
            IEmployeeService employeeService,
            IConfiguration config,
            IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _pageSizeLimit = config.GetValue<int>("PageSizeLimit");
        }

        /// <summary>
        /// Gets managers partitioned into pages.
        /// </summary>
        /// <param name="pageNumber">Number of the page that contains the needed managers.</param>
        /// <param name="pageSize">The size of the needed page.</param>
        /// <response code="200">Returns list of the requested managers with pagination metadata in the headers.</response>
        [HttpGet("employees/managers")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<EmployeeDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetManagersAsync(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
                return BadRequest(
                    $"'{nameof(pageNumber)}' and '{nameof(pageSize)}' must be greater than 0.");

            if (pageSize > _pageSizeLimit)
                pageSize = _pageSizeLimit;

            var managersCount = await _employeeService.GetManagersCountAsync();
            Response.Headers.AddPaginationMetadata(managersCount, pageSize, pageNumber);

            var managers = await _employeeService.ListManagersAsync(pageNumber, pageSize);

            return Ok(_mapper.Map<List<EmployeeDTO>>(managers));
        }
    }
}
