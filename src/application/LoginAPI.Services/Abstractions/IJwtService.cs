using System.Threading.Tasks;
using LoginAPI.Dtos.DTOs;
using LoginAPI.Entities.Models;

namespace LoginAPI.Services.Abstractions
{
    public interface IJwtService
    {
        Task<Tokens> Authenticate(UserWriteDto userWriteDto);
    }
   
}
