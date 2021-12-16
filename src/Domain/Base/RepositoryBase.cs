using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : BaseEntity
    {

        protected DbContext _entities;
        protected readonly DbSet<T> _dbset;
        public RepositoryBase(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }
        public virtual T Add(T entity)
        {
            return _dbset.Add(entity).Entity;
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity).Entity;
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public IList<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IList<T> query = _dbset.Where(predicate).ToList();
            return query;
        }

        public virtual IList<T> GetAll()
        {
            return _dbset.ToList<T>();
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}
