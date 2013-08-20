using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Core.Models.Repository
{
    public interface IBaseRepository<TKey, TEntity> where TEntity:class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties);
        IEnumerable<TEntity> GetPaging(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties, int pIndex, int pSize);
        IQueryable<TEntity> GetAll();
        TEntity GetById(TKey key);
        List<TEntity> SqlQuery(string spName, string[] spParam);
        TEntity Create(TEntity entity, bool saveChanges);
        bool Create(List<TEntity> listEntity, bool saveChanges);
        TEntity Edit(TKey key, TEntity entity, bool saveChanges);
        bool Exists(TKey key);
        bool Delete(TEntity entity, bool saveChanges);
        bool SaveChanges();
    }
}
