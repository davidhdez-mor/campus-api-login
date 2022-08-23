using System.Collections.Generic;

namespace LoginAPI.Dtos.DTOs
{
    public class UserWriteDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        public List<int> Roles { get; set; }
    }
}