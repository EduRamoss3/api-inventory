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
        [Route("create")]
        public async Task<ActionResult<string?>> Create(NormalUserDTO user)
        {
            var result = await _userService.RegisterNormalUser(user);
            if(!result)
            {
                return Problem("Verify all fields and try again");
            }
            return Created();
        }

    }
}

