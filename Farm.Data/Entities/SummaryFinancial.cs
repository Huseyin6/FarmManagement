using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Entities
{
    public class SummaryFinancial
    {
        public string Name { get; set; }
        public decimal Sum { get; set; }

        [NotMapped]
        public int Month { get; set; }
    }
}
