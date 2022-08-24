using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoginAPI.Dtos.DTOs;
using LoginAPI.Entities.Models;
using LoginAPI.Persistence.Abstractions;
using LoginAPI.Services.Abstractions;
using Microsoft.AspNetCore.DataProtection;

namespace LoginAPI.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;

        public UserService(IRepositoryWrapper repository, IMapper mapper, IDataProtectionProvider provider)
        {
            _repository = repository;
            _mapper = mapper;
            _protector = provider.CreateProtector("User.Protector");
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
            var roleIds = userWriteDto.Roles;
            var roles = await _repository
                .RoleRepository
                .GetByCondition(role => roleIds.Any( roleId => role.Id.Equals(roleId)));
           
            var user = new User()
            {
                Username = userWriteDto.Username,
                Password = _protector.Protect(userWriteDto.Password),
                Roles = roles
            };
            _repository.UserRepository.Create(user);
            await _repository.Save();
            var userReadDto = _mapper.Map<UserReadDto>(user);
            return userReadDto;
        }

        public async Task<UserWriteDto> UpdateUser(int id, UserWriteDto userWriteDto)
        {
            var roleIds = userWriteDto.Roles;
            var roles = await _repository
                .RoleRepository
                .GetByCondition(role => roleIds.Any( roleId => role.Id.Equals(roleId)));
            
            var users = await _repository
                .UserRepository
                .GetByCondition(u => u.Id.Equals(id));
            
            var userToUpdate = users.FirstOrDefault();
            
            if (userToUpdate is null)
                return null;

            userToUpdate.Username = userWriteDto.Username;
            userToUpdate.Password = _protector.Protect(userWriteDto.Password);
            userToUpdate.Roles = roles;
            
            _repository.UserRepository.Update(userToUpdate);
            await _repository.Save();

            return userWriteDto;
        }

        public async Task DeleteUser(int id)
        {
            var users = await _repository
                .UserRepository
                .GetByCondition(user => user.Id.Equals(id));
            var userToDelete = users.FirstOrDefault();
            if (userToDelete is null)
                throw new NullReferenceException("User does not exist");
            
            _repository.UserRepository.Delete(userToDelete);
            await _repository.Save();
        }
    }
}