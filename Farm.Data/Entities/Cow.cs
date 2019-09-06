using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Entities
{
    public class Cow: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; }  // In Farm, Sale, Died ...
        public bool IsPregnant { get; set; }
        public bool IsLactation { get; set; }
        public DateTime StateChangeDate { get; set; }

    }
}
