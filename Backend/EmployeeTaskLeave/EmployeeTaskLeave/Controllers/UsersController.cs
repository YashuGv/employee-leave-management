using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskLeaveManagement.Application.Common;
using TaskLeaveManagement.Application.Interfaces.Services;
using TaskLeaveManagement.Application.Services;

namespace EmployeeTaskLeave.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();
            var response = new ApiResponse<object>
            {
                Success = true,
                Message = "Users fetched successfully",
                Data = users,
                StatusCode = 200
            };
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedUsers([FromQuery] PaginationParams paginationParams, [FromQuery] string? role)
        {
            var users = await userService.GetPagedUsersAsync(paginationParams, role);

            var response = new ApiResponse<object>
            {
                Success = true,
                Message = "Users fetched successfully",
                Data = users,
                StatusCode = 200
            };

            return Ok(response);
        }
    }
}
