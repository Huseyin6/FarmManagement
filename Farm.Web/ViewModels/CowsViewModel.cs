using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.ViewModels
{
    public class CowsViewModel:BaseViewModel
    {
        public bool IsPregnant { get; set; }
        public bool IsLactation { get; set; }
        public SelectList StateSelectList { get; set; }
    }
}