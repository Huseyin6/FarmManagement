﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Entities
{
    public class Calf :BaseEntity
    {  
        public int Sex { get; set; }
        public bool DrinkMilk { get; set; } // Does He/She Drink Milk ?
    }
}
