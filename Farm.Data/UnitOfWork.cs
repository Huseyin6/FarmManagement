using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farm.Data.Interfaces;
using Farm.Data.Repository;

namespace Farm.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private MainContext _mainContext;
        public UnitOfWork(MainContext mainContext)
        {
            _mainContext = mainContext;
            CowsRepository = new RepositoryCows(_mainContext);
        }
        public ICowsRepository CowsRepository { get; private set; }

        public int Complete()
        {
          return  _mainContext.SaveChanges();
        }

        public void Dispose()
        {
            _mainContext.Dispose();
        }
    }
}
