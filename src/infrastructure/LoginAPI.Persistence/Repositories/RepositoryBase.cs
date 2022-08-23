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

        public async Task<List<T>> GetAll()
        {
            return await LoginContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await LoginContext.Set<T>()
                .Where(expression)
                .ToListAsync();
        }

        public void Create(T entity)
        {
            LoginContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            LoginContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            LoginContext.Set<T>().Remove(entity);
        }
    }
}