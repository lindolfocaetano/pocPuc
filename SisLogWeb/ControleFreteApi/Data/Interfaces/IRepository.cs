using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControleFreteApi.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int? id);
        TEntity GetById(Guid id);
        TEntity GetById(string id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        
        void Update(TEntity entity);
    }
}
