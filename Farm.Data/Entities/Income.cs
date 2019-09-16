using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Entities
{
    public class Income: FinansalBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int IncomeTypeId { get; set; }
        public virtual IncomeType IncomeType { get; set; }
    }
}
