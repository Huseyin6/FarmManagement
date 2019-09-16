using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Entities
{
    public class Expense: FinansalBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int ExpenseTypeId { get; set; }
        public virtual ExpenseType  ExpenseType { get; set; }
    }
}
