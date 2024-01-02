using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("api/employees")]
    [ApiController]
    public class EmployeeOrdersController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeOrdersController(
            IEmployeeService employeeService,
            IConfiguration config,
            IMapper mapper,
            IValidator<EmployeeWithoutIdDTO> validator)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Calculates average order amount for an employee.
        /// </summary>
        /// <param name="employeeId">The Id property of the needed employee.</param>
        /// <response code="200">Returns the average order amount for an employee.</response>
        /// <response code="404">The employee with the given Id doesn't exist.</response>
        [HttpGet("{employeeId}/average-order-amount")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public async Task<IActionResult> AverageOrderAmountForEmployee(int employeeId)
        {
            if (!await _employeeService.EmployeeExistsAsync(employeeId))
                return NotFound();

            var averageOrderAmount = await _employeeService.
                CalculateAverageOrderAmountAsync(employeeId);

            return Ok(averageOrderAmount);
        }
    }
}
