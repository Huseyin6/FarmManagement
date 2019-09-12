using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Farm.Web.ViewModels
{
    public class CowsViewModel
    {
        [Required(ErrorMessage ="Küpe Numarası Boş Olamaz!")]
        public string EaringNo { get; set; }
        [Required(ErrorMessage ="Durumu Boş Olamaz!")]
        public int State { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Name { get; set; }
        public bool IsPregnant { get; set; }
        public bool IsLactation { get; set; }
    }
}