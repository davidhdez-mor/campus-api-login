using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LoginAPI.Persistence.Abstractions;
using LoginAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected LoginContext LoginContext { get; set; }

        public RepositoryBase(LoginContext loginContext)
        {
            LoginContext = loginContext;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await LoginContext.Set<T>().ToListAsync();
        }

        public virtual async Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await LoginContext.Set<T>()
                .Where(expression)
                .ToListAsync();
        }

        public virtual void Create(T entity)
        {
            LoginContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            LoginContext.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            LoginContext.Set<T>().Remove(entity);
        }
    }
}