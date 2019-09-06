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
        public RepositoryBase(DbContext maincontext)// miras alanlar kullanabilmesi için bir context vermeleri gerek
        {
            _dbContext = maincontext;
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

        IEnumerable<T> IRepository<T>.GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
