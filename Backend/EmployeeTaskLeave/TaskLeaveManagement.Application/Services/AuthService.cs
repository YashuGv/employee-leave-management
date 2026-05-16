using BCrypt.Net;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLeaveManagement.Application.DTOs.Auth;
using TaskLeaveManagement.Application.Exceptions;
using TaskLeaveManagement.Application.Interfaces.Repositories;
using TaskLeaveManagement.Application.Interfaces.Services;
using TaskLeaveManagement.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskLeaveManagement.Application.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IValidator<RegisterRequestDto> _validator;
        public AuthService(
            IUserRepository userRepository,
            IJwtService jwtService,
            IValidator<RegisterRequestDto> validator)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _validator = validator;
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

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!isPasswordValid)
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

        public async Task RegisterAsync(RegisterRequestDto request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(x => x.ErrorMessage)
                    .ToList();

                throw new BadRequestException(
                    string.Join(", ", errors));
            }

            var existingUser =
                await _userRepository.GetByEmailAsync(request.Email);

            if (existingUser != null)
            {
                throw new BadRequestException(
                    "Email already exists");
            }

            var hashedPassword =
                BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = hashedPassword,
                Role = request.Role
            };

            await _userRepository.AddAsync(user);
        }
    }
}
