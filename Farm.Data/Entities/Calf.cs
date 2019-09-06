using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Entities
{
    public class Calf :BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MyProperty { get; set; }
        public int Sex { get; set; }
        public bool DrinkMilk { get; set; } // Does He/She Drink Milk ?

    }
}
