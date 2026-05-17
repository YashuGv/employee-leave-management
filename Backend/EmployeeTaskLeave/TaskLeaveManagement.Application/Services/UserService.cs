using AutoMapper;
using TaskLeaveManagement.Application.Common;
using TaskLeaveManagement.Application.DTOs;
using TaskLeaveManagement.Application.Exceptions;
using TaskLeaveManagement.Application.Interfaces.Repositories;
using TaskLeaveManagement.Application.Interfaces.Services;

namespace TaskLeaveManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            if (!users.Any())
            {
                throw new NotFoundException("No users found");
            }

            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<List<UserDto>> GetPagedUsersAsync(PaginationParams paginationParams, string? role)
        {
            var users = await _userRepository.GetPagedUsersAsync(
                paginationParams.PageNumber,
                paginationParams.PageSize,
                role);

            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
