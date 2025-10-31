using Microsoft.AspNetCore.Mvc;
using PLCHome.Api.DTOs;
using PLCHome.Api.Services;

namespace PLCHome.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth) => _auth = auth;

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthRegisterDto dto)
        {
            try
            {
                var res = await _auth.RegisterAsync(dto);
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthLoginDto dto)
        {
            try
            {
                var res = await _auth.LoginAsync(dto);
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(new { error = ex.Message }); }
        }
    }
}
