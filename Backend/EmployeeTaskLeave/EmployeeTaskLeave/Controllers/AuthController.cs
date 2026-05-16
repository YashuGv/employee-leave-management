using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskLeaveManagement.Application.Common;
using TaskLeaveManagement.Application.DTOs.Auth;
using TaskLeaveManagement.Application.Interfaces.Services;

namespace EmployeeTaskLeave.API.Controllers
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var result = await _authService.LoginAsync(request);
            var response = new ApiResponse<object>
            {
                Success = true,
                Message = "Login successful",
                Data = result,
                StatusCode = 200
            };

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            await _authService.RegisterAsync(request);

            var response = new ApiResponse<object>
            {
                Success = true,
                Message = "User registered successfully",
                StatusCode = 200
            };

            return Ok(response);
        }
    }
}
