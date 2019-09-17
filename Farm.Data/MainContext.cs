using Farm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data
{
    public class MainContext: DbContext
    {
        public MainContext(): base("name=heroku-postgre-db"){
        }
        public DbSet<Cattle> Cattles { get; set; }
        //public DbSet<State> States { get; set; }
        //public DbSet<CattleType> CattleTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<MainContext>(null);
            
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

    }
}
