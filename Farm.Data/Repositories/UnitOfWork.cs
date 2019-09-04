using Farm.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Repositories
{
    public class UnitOfWork<TDbContext> : IUnitOfWork, IDisposable
    where TDbContext : MainContext
    {
        private readonly IDbContextProvider<TDbContext> _dbContextProvider;
        private readonly DbContextTransaction _transaction;
        private readonly IDictionary<Type, object> _repositories;

        public UnitOfWork(IDbContextProvider<TDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
            _transaction = _dbContextProvider.DbContext.Database.BeginTransaction();
            _repositories = new Dictionary<Type, object>();
        }

        public void Commit()
        {
            if (_transaction.UnderlyingTransaction.Connection == null) return;
            _transaction.Commit();
        }

        public void Rollback()
        {
            if (_transaction.UnderlyingTransaction.Connection == null) return;
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public IRepository<TEntity> GetDefaultRepo<TEntity>() where TEntity : class
        {
            return GetRepository<TEntity, IRepository<TEntity>>(
                () => new RepositoryBase<TEntity>(_dbContextProvider.DbContext));
        }
        private TRepo GetRepository<TValue, TRepo>(Func<TRepo> createRepo) where TValue : class where TRepo : class
        {
            if (_repositories.Keys.Contains(typeof(TValue)))
            {
                var value = _repositories[typeof(TValue)] as TRepo;
                if (value != null)
                {
                    return value;
                }
                _repositories.Remove(typeof(TValue));
            }

            var repository = createRepo();
            _repositories.Add(typeof(TValue), repository);
            return repository;
        }
    }
}
