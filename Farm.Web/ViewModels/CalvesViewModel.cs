using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.ViewModels
{
    public class CalvesViewModel:BaseViewModel
    {
        public int Sex { get; set; }
        public bool DrinkMilk { get; set; } // Does He/She Drink Milk ?
        public SelectList SexSelectList { get; set; }
    }
}