using TaskLeaveManagement.Domain.Entities;

namespace TaskLeaveManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllAsync();
        public Task<User?> GetByIdAsync(int id);
        public Task<User?> GetByEmailAsync(string email);
        public Task AddAsync(User user);
    }
}
