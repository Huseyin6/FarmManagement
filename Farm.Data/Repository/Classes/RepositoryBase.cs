using Farm.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Repository
{
    public class RepositoryBase<T>: IRepository<T> where T:class
    {
        protected DbContext  _dbContext;
        private DbSet<T> _dbSet;
        public RepositoryBase(DbContext dbContext)// miras alanlar kullanabilmesi için bir context vermeleri gerek
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveById(int id)
        {
            _dbSet.Remove(GetById(id));
        }

        List<T> IRepository<T>.GetAll()
        {
            return _dbSet.ToList();
        }
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
