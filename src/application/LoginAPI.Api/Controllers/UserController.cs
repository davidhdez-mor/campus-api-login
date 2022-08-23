using System;
using System.Threading.Tasks;
using LoginAPI.Dtos.DTOs;
using LoginAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserWriteDto userWriteDto)
        {
            var user = await _userService.CreateUser(userWriteDto);
            return Created(Request.Path, user);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserWriteDto userWriteDto)
        {
            var user = await _userService.UpdateUser(id, userWriteDto);
            if (user is null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return NoContent();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            
        }
    }
}