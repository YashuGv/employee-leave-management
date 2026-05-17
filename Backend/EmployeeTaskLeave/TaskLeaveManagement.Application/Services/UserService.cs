using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;
        public UserService(IUserRepository userRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            const string cacheKey = "all_users";

            if (_memoryCache.TryGetValue(cacheKey,
                out List<UserDto>? cachedUsers))
            {
                return cachedUsers!;
            }

            var users = await _userRepository.GetAllAsync();

            if (!users.Any())
            {
                throw new NotFoundException("No users found");
            }

            var mappedUsers = _mapper.Map<List<UserDto>>(users);

            var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            _memoryCache.Set(cacheKey,mappedUsers,cacheOptions);

            return mappedUsers;
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
