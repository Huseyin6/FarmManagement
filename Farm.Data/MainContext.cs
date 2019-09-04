using System;
using System.Data.Entity;
using Farm.Domain.Entities;
namespace Farm.Data
{   
    
    public class MainContext : DbContext
    {
        
        public MainContext():base("Name=heroku-postgre-db")
        {
            var deneme=Database.Connection.ConnectionString;
        }    
        public DbSet<Cow> Cows { get; set; }
        public DbSet<Calf> Calves { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cow>();

            modelBuilder.Entity<Calf>();
            modelBuilder.HasDefaultSchema("public");

            base.OnModelCreating(modelBuilder);
        }
    }
}
