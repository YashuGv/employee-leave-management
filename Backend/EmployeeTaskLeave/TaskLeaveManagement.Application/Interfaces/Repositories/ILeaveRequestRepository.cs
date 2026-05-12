using TaskLeaveManagement.Domain.Entities;

namespace TaskLeaveManagement.Application.Interfaces.Repositories
{
    public interface ILeaveRequestRepository
    {
        public Task<List<LeaveRequest>> GetAllAsync();
        public Task<LeaveRequest?> GetByIdAsync(int id);
        public Task AddAsync(LeaveRequest leaveRequest);
    }
}
