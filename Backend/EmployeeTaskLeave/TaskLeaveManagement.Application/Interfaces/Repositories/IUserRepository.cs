using TaskLeaveManagement.Domain.Entities;

namespace TaskLeaveManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
