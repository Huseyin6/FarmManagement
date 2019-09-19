using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Farm.Web.ViewModels
{
    public class CowsViewModel:BaseViewModel
    {
        public bool IsPregnant { get; set; }
        public bool IsLactation { get; set; }
    }
}