using TaskLeaveManagement.Application.DTOs;

namespace TaskLeaveManagement.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
    }
}
