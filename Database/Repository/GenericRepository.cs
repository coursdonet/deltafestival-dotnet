using Database;
using DeltaFestival.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaFestival.Repository
{
    public abstract class GenericRepository<T> :
    IGenericRepository<T> where T : class, new()
    {

        protected readonly EfContext _efContext;


        public GenericRepository(EfContext dbContext)
        {
            _efContext = dbContext;
        }

        public virtual IQueryable<T> GetAll()
        {

            return _efContext.Set<T>();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _efContext.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _efContext.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _efContext.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            //_entities.Entry(entity).State = System.Data.EntityState.Modified;
            throw new NotImplementedException();
        }

        public virtual void Save()
        {
            _efContext.SaveChanges();
        }
    }
}
