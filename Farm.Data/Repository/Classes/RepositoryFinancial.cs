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

        public decimal GetTotalForIncomeOrExpense(int IncomeOrExpense)
        {
            var sql = "";
            if (IncomeOrExpense == 0)
            {
                sql = $@"select sum(""Total"")
                        from ""FinancialAssets""
                        where ""FinancialAssetTypeId""<5;";
            }
            else if (IncomeOrExpense == 1)
            {
                sql = $@"select sum(""Total"")
                        from ""FinancialAssets""
                        where ""FinancialAssetTypeId"">=5;";
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

        public IEnumerable<SummaryFinancial> GetTotalForFinancialType(int month, int financialTypeGroup = 0)
        {
            var sql = "";
            if (financialTypeGroup == 0)
            {
                sql = $@"select fat.""Name"", sum(fa.""Total"") as ""Sum""
                        from ""FinancialAssets"" fa
                        join ""FinancialAssetTypes"" fat on fat.""Id""=fa.""FinancialAssetTypeId""
                        where date_part('month',""TransactionDate"")={month} and fa.""FinancialAssetTypeId"" <5
                        group by fat.""Id""";
            }
            else if (financialTypeGroup == 1)
            {
                sql = $@"select fat.""Name"", sum(fa.""Total"") as ""Sum""
                        from ""FinancialAssets"" fa
                        join ""FinancialAssetTypes"" fat on fat.""Id""=fa.""FinancialAssetTypeId""
                        where date_part('month',""TransactionDate"")={month} and fa.""FinancialAssetTypeId"" >=5
                        group by fat.""Id""";
            }
            var result = _dbContext.Database.SqlQuery<SummaryFinancial>(sql);
            return result;
        }
    }
}
