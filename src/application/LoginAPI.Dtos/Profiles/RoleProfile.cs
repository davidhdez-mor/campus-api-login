using AutoMapper;
using LoginAPI.Dtos.DTOs;
using LoginAPI.Entities.Models;

namespace LoginAPI.Dtos.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleReadDto>();
        }
    }
}