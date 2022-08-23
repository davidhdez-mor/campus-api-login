using System.Collections.Generic;

namespace LoginAPI.Entities.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}