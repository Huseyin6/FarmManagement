 using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farm.Data.Entities;
using Farm.Data.Interfaces;
using Farm.Data.Repositories.Classes;
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
            CowsRepository = new RepositoryCows(_mainContext);
            CalvesRepository = new RepositoryCalves(_mainContext);
            HeiferRepository = new RepositoryHeifers(_mainContext);
            SteerRepository=new RepositorySteers(_mainContext);
        }
        public ICowsRepository CowsRepository { get; private set; }
        public ICalvesRepository CalvesRepository { get; private set; }
        public IRepository<Heifer> HeiferRepository { get;private set; }
        public IRepository<Steer> SteerRepository { get;private set; }
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
