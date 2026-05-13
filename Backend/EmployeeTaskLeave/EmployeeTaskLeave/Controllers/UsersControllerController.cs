using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskLeaveManagement.Application.Common;
using TaskLeaveManagement.Application.Interfaces.Services;

namespace EmployeeTaskLeave.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersControllerController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersControllerController(IUserService userService)
        {
            this.userService = userService;
        }

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
    }
}
