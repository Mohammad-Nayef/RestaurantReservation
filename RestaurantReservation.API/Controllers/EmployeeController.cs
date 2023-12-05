using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API.Extensions;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly int _pageSizeLimit;

        public EmployeeController(
            IEmployeeService employeeService,
            IConfiguration config,
            IMapper mapper)
        {
            _employeeService = employeeService ??
                throw new ArgumentNullException(nameof(employeeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _pageSizeLimit = config.GetValue<int>("PageSizeLimit");
        }

        /// <summary>
        /// Gets employees partitioned into pages.
        /// </summary>
        /// <param name="pageNumber">Number of the page that contains the needed employees.</param>
        /// <param name="pageSize">The size of the needed page.</param>
        /// <response code="200">Returns list of the requested employees with pagination metadata in the headers.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<EmployeeDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployeesAsync(int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > _pageSizeLimit)
                pageSize = _pageSizeLimit;

            var employees = await _employeeService.GetAllAsync(pageNumber, pageSize);
            var employeesCount = await _employeeService.GetEmployeesCountAsync();

            Response.Headers.AddPaginationMetadata(employeesCount, pageSize, pageNumber);

            return Ok(_mapper.Map<List<EmployeeDTO>>(employees));
        }

        /// <summary>
        /// Gets managers partitioned into pages.
        /// </summary>
        /// <param name="pageNumber">Number of the page that contains the needed managers.</param>
        /// <param name="pageSize">The size of the needed page.</param>
        /// <response code="200">Returns list of the requested managers with pagination metadata in the headers.</response>
        [HttpGet("managers")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<EmployeeDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetManagersAsync(int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > _pageSizeLimit)
                pageSize = _pageSizeLimit;

            var managers = await _employeeService.ListManagersAsync(pageNumber, pageSize);
            var managersCount = await _employeeService.GetManagersCountAsync();

            Response.Headers.AddPaginationMetadata(managersCount, pageSize, pageNumber);

            return Ok(_mapper.Map<List<EmployeeDTO>>(managers));
        }

        /// <summary>
        /// Gets an employee by their Id.
        /// </summary>
        /// <param name="employeeId">The Id property of the needed employee.</param>
        /// <response code="200">Returns the requested employee.</response>
        /// <response code="404">The employee with the given Id doesn't exist.</response>
        [HttpGet("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployeeAsync(int employeeId)
        {
            Employee employee;

            try
            {
                employee = await _employeeService.GetAsync(employeeId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EmployeeDTO>(employee));
        }

        /// <summary>
        /// Create and store a new employee.
        /// </summary>
        /// <param name="newEmployee">Properties of the new employee.</param>
        /// <response code="201">Returns the employee with a new Id and their URI is in the headers.</response>
        /// <response code="422">There's an invalid foreign key returned in the response body.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateEmployeeAsync(EmployeeWithoutIdDTO newEmployee)
        {
            int newId = 0;

            try
            {
                newId = await _employeeService.
                    CreateAsync(_mapper.Map<Employee>(newEmployee));
            }
            catch (DbUpdateException ex)
            {
                return UnprocessableEntity(
                    $"Invalid foreign key: {ex.InnerException.Message.ExtractForeignKey()}");
            }

            var responseEmployee = _mapper.Map<EmployeeDTO>(newEmployee);
            responseEmployee.Id = newId;

            return Created($"api/employees/{newId}", responseEmployee);
        }

        /// <summary>
        /// Update an employee with a specific Id.
        /// </summary>
        /// <param name="employeeId">The Id of the employee to update.</param>
        /// <param name="updatedEmployee">The employee with updated value(s).</param>
        /// <response code="404">The employee with the given Id doesn't exist.</response>
        /// <response code="422">There's an invalid foreign key returned in the response body.</response>
        /// <response code="204">The employee is updated successfully.</response>
        [HttpPut("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateEmployeeAsync(
            int employeeId,
            EmployeeWithoutIdDTO updatedEmployee)
        {
            var employeeWithId = _mapper.Map<Employee>(updatedEmployee);
            employeeWithId.Id = employeeId;

            try
            {
                await _employeeService.UpdateAsync(employeeWithId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateException ex)
            {
                return UnprocessableEntity(
                    $"Invalid foreign key: {ex.InnerException.Message.ExtractForeignKey()}");
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an employee with a specific Id.
        /// </summary>
        /// <param name="employeeId">The Id of the employee to delete.</param>
        /// <response code="404">The employee with the given Id doesn't exist.</response>
        /// <response code="204">The employee is deleted successfully.</response>
        [HttpDelete("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                await _employeeService.DeleteAsync(employeeId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
