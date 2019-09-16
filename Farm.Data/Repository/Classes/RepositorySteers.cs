using Farm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Repository.Classes
{
    public class RepositorySteers: RepositoryBase<Steer>
    {
        public RepositorySteers(MainContext mainContext):base(mainContext)
        {

        }
    }
}
