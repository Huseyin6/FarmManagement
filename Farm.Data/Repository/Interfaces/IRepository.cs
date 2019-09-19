using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        List<T> GetAll();
        List<T> GetMany(Expression<Func<T, bool>> where = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveById(int id);
        void Update(T entity);
    }
}
