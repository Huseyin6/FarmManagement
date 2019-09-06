using Farm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data
{
    public class MainContext: DbContext
    {
        public MainContext(): base("name=heroku-postgre-db"){
        }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Cow> Cows { get; set; }
         
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MainContext>(null);
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

    }
}
