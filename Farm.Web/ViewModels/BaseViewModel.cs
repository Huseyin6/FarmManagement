using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Farm.Web.ViewModels
{
    public class BaseViewModel
    {
        [Required(ErrorMessage = "Küpe Numarası Boş Olamaz!")]
        public string EaringNo { get; set; }

        [Required(ErrorMessage = "Durumu Boş Olamaz!")]
        public int StateId { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}