using TaskLeaveManagement.Domain.Entities;

namespace TaskLeaveManagement.Application.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task AddAsync(TaskItem taskItem);
    }
}
