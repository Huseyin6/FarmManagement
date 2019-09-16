using Farm.Data.Entities;
using Farm.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Repository.Interfaces
{
    public interface ICalvesRepository:IRepository<Calf>
    {
        IEnumerable<Calf> GetDrinkMilkCalves();
    }
}
