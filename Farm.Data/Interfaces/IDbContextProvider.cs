using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Interfaces
{
    public interface IDbContextProvider<TDbContext> where TDbContext : MainContext
    {
        TDbContext DbContext { get; }
    }
}
