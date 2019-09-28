using Farm.Data.Entities;
using Farm.Data.Interfaces;
using Farm.Data.Repository;
using Farm.Data.Repository.Classes;
using Farm.Data.Repository.Interfaces;

namespace Farm.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private MainContext _mainContext;
        public UnitOfWork(MainContext mainContext)
        {
            _mainContext = mainContext;
            Repository = new RepositoryBase<Cattle>(_mainContext);
            FinancialRepo = new RepositoryFinancial(_mainContext);
        }
        public IRepository<Cattle> Repository { get;private set; }
        public IFinancialRepository FinancialRepo { get;private set; }
        public int Commit()
        {
          return  _mainContext.SaveChanges();
        }

        public void Dispose()
        {
            _mainContext.Dispose();
        }
    }
}
