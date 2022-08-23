using System;
using System.Threading.Tasks;
using LoginAPI.Persistence.Abstractions;
using LoginAPI.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace LoginAPI.Persistence.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly LoginContext _loginContext;
        private readonly IServiceProvider _serviceProvider;

        public IUserRepository UserRepository => _serviceProvider.GetService<IUserRepository>();
        public IRoleRepository RoleRepository => _serviceProvider.GetService<IRoleRepository>();

        public RepositoryWrapper(LoginContext context, IServiceProvider serviceProvider)
        {
            _loginContext = context;
            _serviceProvider = serviceProvider;
        }
        
        public async Task Save()
        {
            await _loginContext.SaveChangesAsync();
        }
    }
}