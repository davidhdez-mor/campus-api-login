using AutoMapper;
using LoginAPI.Dtos.DTOs;
using LoginAPI.Entities.Models;

namespace LoginAPI.Dtos.Profiles
{
    public class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<Tokens, TokenReadDto>();
            CreateMap<TokenWriteDto, Tokens>();
        }
    }
}