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
        public DbSet<Cow> Cows { get; set; }
        public DbSet<Calf> Calves { get; set; }
        public DbSet<Heifer> Heifers { get; set; }
        public DbSet<Steer> Steers { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<IncomeType> IncomeTypes { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MainContext>(null);
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

    }
}
