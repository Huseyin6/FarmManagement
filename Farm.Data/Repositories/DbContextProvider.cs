using Farm.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Repositories
{
    public sealed class DbContextProvider<TDbContext> : IDbContextProvider<TDbContext> where TDbContext : MainContext
    {
        public TDbContext DbContext { get; }

        public DbContextProvider(TDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
