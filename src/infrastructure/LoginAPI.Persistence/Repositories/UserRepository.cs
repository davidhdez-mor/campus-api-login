using LoginAPI.Entities.Models;
using LoginAPI.Persistence.Abstractions;
using LoginAPI.Persistence.Context;

namespace LoginAPI.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(LoginContext loginContext) : base(loginContext)
        {
        }
    }
}