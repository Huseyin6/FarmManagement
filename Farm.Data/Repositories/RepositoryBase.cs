using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(MainContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext can not be null.");

            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            _dbContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public T Get(Expression<Func<T, bool>> where, params string[] include)
        {
            var q = _dbSet.Where(where);
            for (int i = 0; i < include.Length; i++)
            {
                q = q.Include(include[i]);
            }
            return q.FirstOrDefault();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IQueryable<T> GetMany(Expression<Func<T, bool>> where = null)
        {
            return (where == null ? _dbSet : _dbSet.Where(where));
        }

        public IQueryable<T> GetMany(Expression<Func<T, bool>> where, params string[] include)
        {
            var q = GetMany(where);
            for (int i = 0; i < include.Length; i++)
            {
                q = q.Include(include[i]);
            }
            return q;
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void InsertOrUpdate(T entity)
        {
            if(_dbContext.Entry(entity).State==EntityState.Detached){
                _dbSet.Add(entity);
            }
            else{
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
