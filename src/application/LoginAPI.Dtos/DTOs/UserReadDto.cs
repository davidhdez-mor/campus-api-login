using System.Collections.Generic;

namespace LoginAPI.Dtos.DTOs
{
    public class UserReadDto
    {
        public string Username { get; set; }
        public List<RoleReadDto> Roles { get; set; }
    }
}