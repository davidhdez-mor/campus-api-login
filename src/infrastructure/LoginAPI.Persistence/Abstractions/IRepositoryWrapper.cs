using System.Threading.Tasks;

namespace LoginAPI.Persistence.Abstractions
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        Task Save();
    }
}