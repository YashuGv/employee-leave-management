using TaskLeaveManagement.Application.Common;
using TaskLeaveManagement.Application.DTOs;

namespace TaskLeaveManagement.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<List<UserDto>> GetPagedUsersAsync(PaginationParams paginationParams, string? role);
    }
}
