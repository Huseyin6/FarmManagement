using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Entities
{
    public class FinancialAsset
    {
        public int Id { get; set; }
        public int FinancialAssetTypeId { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Total { get; set; }
        public DateTime TransactionDate { get; set; }

        public virtual FinancialAssetType FinancialAssetType { get; set; }
    }
}
