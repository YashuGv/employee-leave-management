using TaskLeaveManagement.Domain.Entities;

namespace TaskLeaveManagement.Application.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        public Task<List<TaskItem>> GetAllAsync();
        public Task<TaskItem?> GetByIdAsync(int id);
        public Task AddAsync(TaskItem taskItem);
    }
}
