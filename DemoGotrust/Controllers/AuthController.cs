using BAL.DTOs;
using BAL.Services;
using DemoGotrust.Models.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoGotrust.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST api/<AuthController>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<JwtDto>> Post([FromBody] LoginRequest loginRequest)
        {
            try
            {

                var obj = _authService.login(loginRequest.username, loginRequest.password);

                if (obj == null) return BadRequest("Invalid credentials");

                return Ok(obj);

            } catch (Exception ex)
            {
                throw;
            }
        }
    }
}
