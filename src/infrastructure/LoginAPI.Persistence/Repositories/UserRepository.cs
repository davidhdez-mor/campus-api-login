using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LoginAPI.Entities.Models;
using LoginAPI.Persistence.Abstractions;
using LoginAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(LoginContext loginContext) : base(loginContext)
        {
        }

        public override async Task<List<User>> GetAll()
        {
            return await LoginContext.Set<User>()
                .Include(user => user.Roles)
                .ToListAsync();
        }

        public override async Task<List<User>> GetByCondition(Expression<Func<User, bool>> expression)
        {
            return await LoginContext.Set<User>()
                .Include(user => user.Roles)
                .Where(expression)
                .ToListAsync();
        }
    }
}