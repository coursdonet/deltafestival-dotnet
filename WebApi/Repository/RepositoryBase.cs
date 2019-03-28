using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WebApi.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected EfContext EfContext { get; set; }

        public RepositoryBase(EfContext _EfContext)
        {
            this.EfContext = _EfContext;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await this.EfContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this.EfContext.Set<T>().Where(expression).ToListAsync();
        }

        public void Create(T entity)
        {
            this.EfContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.EfContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.EfContext.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await this.EfContext.SaveChangesAsync();
        }
    }
}
