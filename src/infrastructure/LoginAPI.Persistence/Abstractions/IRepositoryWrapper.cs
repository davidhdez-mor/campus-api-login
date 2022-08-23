using System.Threading.Tasks;

namespace LoginAPI.Persistence.Abstractions
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepository { get; }
        ITokenRepository TokenRepository { get; }
        Task Save();
    }
}