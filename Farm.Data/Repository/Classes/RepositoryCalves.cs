using Farm.Data.Entities;
using Farm.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Repository.Classes
{
    public class RepositoryCalves : RepositoryBase<Calf>, ICalvesRepository
    {
        private DbSet<Calf> _calfDbSet;
        public RepositoryCalves(MainContext mainContext) : base(mainContext)// RepositoryBase'i miras aldığım için bir context tanımlamam lazım.
        {
            _calfDbSet = mainContext.Calves;
        }
        public IEnumerable<Calf> GetDrinkMilkCalves()
        {
            return _calfDbSet.Where(m => m.DrinkMilk);
        }
    }
}
