using API_Inventario.Extensions;
using FluentValidation;
using INV.Application.DTO;
using INV.Application.Services.Interfaces;
using INV.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace INV_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AccountController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Login(string email, string password)
        {
            var result = await _userService.Login(email, password);
            if(result != null)
            {
                var token = _tokenService.GenerateToken(result);
                return Ok(token);
            }
            return Problem(
              detail: "Email and password do not match",
              instance: HttpContext.Request.Path,
              statusCode: 400,
              title: "Error of validation",
              type: "https://httpstatuses.com/400"
              );
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromServices] IValidator<NormalUserDTO> validate, NormalUserDTO user)
        {
            var validating = await validate.ValidateAsync(user);
            if (!validating.IsValid)
            {
                validating.AddToModelState(this.ModelState);

              return Problem(
              detail: string.Join(" | ", ModelState.Values
             .SelectMany(v => v.Errors)
             .Select(e => e.ErrorMessage)),
              instance: HttpContext.Request.Path,
              statusCode: 400,
              title: "Error of validation",
              type: "https://httpstatuses.com/400"
              );
            }

            var result = await _userService.RegisterNormalUser(user);

            if (result.HasError)
            {
                return Problem("Verify all fields and try again");
            }
            if(result._Entity == null)
            {
                return Problem("Error creating new user, try again later");
            }
            return Created($"api/user/profile/",result._Entity);
        }

    }
}

