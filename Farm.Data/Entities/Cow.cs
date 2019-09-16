using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Entities
{
    public class Cow: BaseEntity
    {
        public bool IsPregnant { get; set; }
        public bool IsLactation { get; set; }
        public DateTime StateChangeDate { get; set; }
    }
}
