using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Entities
{
    public abstract class FinansalBaseEntity
    {
        public decimal Total { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
