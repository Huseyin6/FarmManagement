using Farm.Data.Entities;
using Farm.Data.Interfaces;
using Farm.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Repositories.Classes
{
    public  class RepositoryHeifers: RepositoryBase<Heifer>
    {
        public RepositoryHeifers(MainContext mainContext):base(mainContext)
        {
            
        }
    }
}
