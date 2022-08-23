using LoginAPI.Entities.Models;
using LoginAPI.Persistence.Abstractions;
using LoginAPI.Persistence.Context;

namespace LoginAPI.Persistence.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(LoginContext loginContext) : base(loginContext)
        {
        }
    }
}