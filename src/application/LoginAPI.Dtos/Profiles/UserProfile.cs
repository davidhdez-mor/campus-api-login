using AutoMapper;
using LoginAPI.Dtos.DTOs;
using LoginAPI.Entities.Models;

namespace LoginAPI.Dtos.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>().ReverseMap();
            CreateMap<User, RoleReadDto>();
            CreateMap<UserWriteDto, User>();
        }
    }
}