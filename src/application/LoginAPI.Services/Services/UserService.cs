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
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public UserService(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<UserReadDto>> GetUsers()
        {
            var users = await _repository.UserRepository.GetAll();

            var mapUsers = _mapper.Map<List<UserReadDto>>(users);
            return mapUsers;
        }

        public async Task<UserReadDto> GetUserById(int id)
        {
           var users = await _repository.UserRepository.GetByCondition(user => user.Id.Equals(id));

           var mapUsers = _mapper.Map<List<UserReadDto>>(users);
           return mapUsers.Count > 0 ? mapUsers.FirstOrDefault() : null;
        }

        public async Task<UserReadDto> CreateUser(UserWriteDto userWriteDto)
        {
            var user = _mapper.Map<User>(userWriteDto);
            _repository.UserRepository.Create(user);
            await _repository.Save();
            var userReadDto = _mapper.Map<UserReadDto>(user);
            return userReadDto;
        }

        public async Task<UserWriteDto> UpdateUser(int id, UserWriteDto userWriteDto)
        {
            var users = await _repository.UserRepository.GetByCondition(u => u.Id.Equals(id));
            var userToUpdate = users.FirstOrDefault();
            
            if (userToUpdate is null)
                return null;
            
            _repository.UserRepository.Update(userToUpdate);
            await _repository.Save();

            return userWriteDto;
        }

        public async Task DeleteUser(int id)
        {
            var users = await _repository.UserRepository.GetByCondition(user => user.Id.Equals(id));
            var userToDelete = users.FirstOrDefault();
            if (userToDelete is null)
                throw new NullReferenceException("User does not exist");
            
            _repository.UserRepository.Delete(userToDelete);
            await _repository.Save();
        }
    }
}