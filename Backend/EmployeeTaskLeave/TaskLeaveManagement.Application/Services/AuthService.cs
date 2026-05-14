using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLeaveManagement.Application.DTOs.Auth;
using TaskLeaveManagement.Application.Exceptions;
using TaskLeaveManagement.Application.Interfaces.Repositories;
using TaskLeaveManagement.Application.Interfaces.Services;

namespace TaskLeaveManagement.Application.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        public AuthService(
            IUserRepository userRepository,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDto> LoginAsync(
            LoginRequestDto request)
        {
            var user = await _userRepository
                .GetByEmailAsync(request.Email);

            if (user == null)
            {
                throw new UnauthorizedException("Invalid credentials");
            }

            if (user.Password != request.Password)
            {
                throw new UnauthorizedException("Invalid credentials");
            }

            var token = _jwtService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(1)
            };
        }
    }
}
