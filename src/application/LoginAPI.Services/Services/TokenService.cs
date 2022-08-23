using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoginAPI.Dtos.DTOs;
using LoginAPI.Entities.Models;
using LoginAPI.Persistence.Abstractions;
using LoginAPI.Services.Abstractions;

namespace LoginAPI.Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public TokenService(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TokenReadDto>> GetToken()
        {
           var tokens = await _repository.TokenRepository.GetAll();
           var mapTokens = _mapper.Map<List<TokenReadDto>>(tokens);
           return mapTokens;
        }

        public async Task<TokenReadDto> GetTokenById(int id)
        {
            var tokens = await _repository.TokenRepository.GetByCondition(token => token.Id.Equals(id));
            var mapTokens = _mapper.Map<List<TokenReadDto>>(tokens);
            return mapTokens.Count > 0 ? mapTokens.FirstOrDefault() : null;
        }

        public async Task<TokenReadDto> CreateToken(TokenWriteDto tokenWriteDto)
        {
            var token = _mapper.Map<Tokens>(tokenWriteDto);
            _repository.TokenRepository.Create(token);
            await _repository.Save();
            var tokenReadDto = _mapper.Map<TokenReadDto>(token);
            return tokenReadDto;
        }

        public async Task<TokenWriteDto> UpdateToken(int id, TokenWriteDto tokenWriteDto)
        {
            var tokens = await _repository.TokenRepository.GetByCondition(t => t.Id.Equals(id));
            var tokenToUpdate= tokens.FirstOrDefault();
            
            if (tokenToUpdate is null)
                return null;

            var token = _mapper.Map(tokenWriteDto, tokenToUpdate);
            
            _repository.TokenRepository.Update(tokenToUpdate);
            await _repository.Save();
            
            return tokenWriteDto;
        }

        public async Task DeleteToken(int id)
        {
            var tokens = await _repository.TokenRepository.GetByCondition(t => t.Id.Equals(id));
            var tokenToDelete = tokens.FirstOrDefault();

            if (tokenToDelete is null)
                throw new NullReferenceException("Token does not exist");
            
            _repository.TokenRepository.Delete(tokenToDelete);
            await _repository.Save();
        }
    }
}