using Farm.Data.Entities;
using Farm.Data.Interfaces;
using Farm.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Repository.Classes
{
    public class RepositoryFinancial : RepositoryBase<FinancialAsset>, IFinancialRepository
    {
        public int MyProperty { get; set; }
        public RepositoryFinancial(DbContext dbContext) : base(dbContext)
        {

        }

        public decimal GetTotalForFinancialType(int IncomeOrExpense)
        {
            var sql = "";
            if (IncomeOrExpense == 0)
            {
                sql = $@"select sum(""Total"")
                        from ""FinancialAssets""
                        where ""FinancialAssetTypeId""<5;";
            }
            else if(IncomeOrExpense==1){
                sql = $@"select sum(""Total"")
                        from ""FinancialAssets""
                        where ""FinancialAssetTypeId"">5;";
            }
            try
            {
            var result = _dbContext.Database.SqlQuery<decimal>(sql);
            return result.FirstOrDefault();

            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
