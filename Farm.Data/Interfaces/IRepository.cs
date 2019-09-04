using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data
{
    public interface IRepository<TEntity> where TEntity: class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void InsertOrUpdate(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        TEntity Get(Expression<Func<TEntity, bool>> where, params string[] include);
        TEntity GetById(int id);
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where = null);
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, params string[] include);
        IEnumerable<TEntity> GetAll();
    }

}
