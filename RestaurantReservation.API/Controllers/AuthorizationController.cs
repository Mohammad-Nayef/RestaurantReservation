using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.API.Models;
using RestaurantReservation.API.Services;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Services;
using FluentValidation;
using RestaurantReservation.API.Extensions;

namespace RestaurantReservation.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IValidator<UserWithoutIdDTO> _userRegisterValidator;
        private readonly IValidator<UserLoginDTO> _userLoginValidator;

        public AuthorizationController(
            IUserService userService,
            IMapper mapper,
            ITokenGenerator tokenGenerator,
            IValidator<UserWithoutIdDTO> userWithoutIdValidator,
            IValidator<UserLoginDTO> userLoginValidator)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
            _userRegisterValidator = userWithoutIdValidator;
            _userLoginValidator = userLoginValidator;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="userRegister"></param>
        /// <response code="200">Token for authorization</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterAsync(UserWithoutIdDTO userRegister)
        {
            var validationResult = await _userRegisterValidator.ValidateAsync(userRegister);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.GetImportantProperties());

            var user = _mapper.Map<User>(userRegister);

            try
            {
                await _userService.CreateAsync(user);
            }
            catch(UsernameDuplicateException ex)
            {
                return BadRequest(ex.Message);
            }

            var userWithoutPassword = _mapper.Map<UserWithoutPasswordDTO>(user);
            var token = _tokenGenerator.GenerateToken(userWithoutPassword);

            return Ok(token);
        }

        /// <summary>
        /// Login to an existing user account
        /// </summary>
        /// <param name="userLogin"></param>
        /// <response code="200">Token for authorization</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginAsync(UserLoginDTO userLogin)
        {
            var validationResult = await _userLoginValidator.ValidateAsync(userLogin);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.GetImportantProperties());

            var user = await _userService.
                AuthenticateUserAsync(userLogin.Username, userLogin.Password);

            if (user == null)
                return Unauthorized();

            var userWithoutPassword = _mapper.Map<UserWithoutPasswordDTO>(user);
            var token = _tokenGenerator.GenerateToken(userWithoutPassword);

            return Ok(token);
        }
    }
}
