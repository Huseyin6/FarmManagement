using Farm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Interfaces
{
    public interface ICowsRepository:IRepository<Cow>
    {
        IEnumerable<Cow> GetLactationCows();
        IEnumerable<Cow> GetPregnant();
    }
}
