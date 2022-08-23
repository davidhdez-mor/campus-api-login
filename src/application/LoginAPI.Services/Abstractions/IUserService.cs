using System.Collections.Generic;
using System.Threading.Tasks;
using LoginAPI.Dtos.DTOs;
using LoginAPI.Entities.Models;

namespace LoginAPI.Services.Abstractions
{
    public interface IUserService
    {
        public Task<IEnumerable<UserReadDto>> GetUsers();
        public Task<UserReadDto> GetUserById(int id);
        public Task<UserReadDto> CreateUser(UserWriteDto userWriteDto);
        public Task<UserWriteDto> UpdateUser(int id, UserWriteDto userWriteDto);
        public Task DeleteUser(int id);
    }
}