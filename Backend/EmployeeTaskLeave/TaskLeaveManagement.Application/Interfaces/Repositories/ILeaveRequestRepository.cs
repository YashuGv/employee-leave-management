using TaskLeaveManagement.Domain.Entities;

namespace TaskLeaveManagement.Application.Interfaces.Repositories
{
    public interface ILeaveRequestRepository
    {
        Task<List<LeaveRequest>> GetAllAsync();
        Task<LeaveRequest?> GetByIdAsync(int id);
        Task AddAsync(LeaveRequest leaveRequest);
    }
}
