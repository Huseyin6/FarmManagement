using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Interfaces
{
    public interface IRepository<T> where T:class
    {       
        T GetById(int id);

        List<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void RemoveById(int id);
        void Update(T entity);
    }
}
