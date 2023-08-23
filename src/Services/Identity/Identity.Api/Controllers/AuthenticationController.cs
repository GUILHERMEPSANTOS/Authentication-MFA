using Identity.Api.DTO;
using Identity.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO login)
        {
            var successfulLogin = await _authenticationService.LoginAsync(login);

            return Ok(successfulLogin);
        }

        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAsync([FromBody] NewUserDTO newUser)
        {
            var successfulCreateAccount = await _authenticationService.CreateAsync(newUser);

            return Ok(successfulCreateAccount);
        }
    }
}
