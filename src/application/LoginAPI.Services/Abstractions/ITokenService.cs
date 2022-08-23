using System.Collections.Generic;
using System.Threading.Tasks;
using LoginAPI.Dtos.DTOs;
using LoginAPI.Entities.Models;

namespace LoginAPI.Services.Abstractions
{
    public interface ITokenService
    {
        public Task<IEnumerable<TokenReadDto>> GetToken();
        public Task<TokenReadDto> GetTokenById(int id);
        public Task<TokenReadDto> CreateToken(TokenWriteDto tokenWriteDto);
        public Task<TokenWriteDto> UpdateToken(int id, TokenWriteDto tokenWriteDto);
        public Task DeleteToken(int id);
        
    }
}