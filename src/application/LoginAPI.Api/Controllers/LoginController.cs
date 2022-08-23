using System.Threading.Tasks;
using LoginAPI.Dtos.DTOs;
using LoginAPI.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IJwtService _jwt;

        public LoginController(IJwtService jwt)
        {
            _jwt = jwt;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserWriteDto userWriteDto)
        {
            var token = await _jwt.Authenticate(userWriteDto);
            if (token is null)
                return Unauthorized();

            return Ok(token);
        }
    }
}