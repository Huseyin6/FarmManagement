using Farm.Data.Entities;
using Farm.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Repository
{
    public class RepositoryCows : RepositoryBase<Cow>,ICowsRepository
    {
        private DbSet<Cow> _cowDbSet;
        public RepositoryCows(MainContext mainContext):base(mainContext)// RepositoryBase'i miras aldığım için bir context tanımlamam lazım.
        {
            _cowDbSet = mainContext.Cows;
        }
     
        public IEnumerable<Cow> GetLactationCows()
        {
            return _cowDbSet.Where(m => m.IsLactation);
        }

        public IEnumerable<Cow> GetPregnant()
        {
            return _cowDbSet.Where(m => m.IsPregnant);
        }
    }
}
