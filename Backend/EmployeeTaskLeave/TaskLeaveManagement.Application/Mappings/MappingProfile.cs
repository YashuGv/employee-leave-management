using AutoMapper;
using TaskLeaveManagement.Application.DTOs;
using TaskLeaveManagement.Application.DTOs.Auth;
using TaskLeaveManagement.Domain.Entities;

namespace TaskLeaveManagement.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<RegisterRequestDto, User>();
        }
    }
}
