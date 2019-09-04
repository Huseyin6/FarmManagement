using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetDefaultRepo<TEntity>() where TEntity : class;
        void Commit();
        void Rollback();
    }
}
