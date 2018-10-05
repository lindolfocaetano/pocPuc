using ControleFreteApi.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControleFreteApi.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        internal DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToArray();
        }

        public TEntity GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public TEntity GetById(string id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
