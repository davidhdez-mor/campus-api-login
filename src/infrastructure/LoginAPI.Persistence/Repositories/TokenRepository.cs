using LoginAPI.Entities.Models;
using LoginAPI.Persistence.Abstractions;
using LoginAPI.Persistence.Context;

namespace LoginAPI.Persistence.Repositories
{
    public class TokenRepository : RepositoryBase<Tokens>, ITokenRepository
    {
        public TokenRepository(LoginContext loginContext) : base(loginContext)
        {
        }
    }

}