using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Domain.Entities
{
    public class Cow
    {
        [Key]
        public int Id { get; set; } // Küpe no ya da artı bir küpe no kolonu tanımlanacak.
        public string Name { get; set; }
        public int State { get; set; } // Çiftlikte, Satıldı, Öldü ...
        public DateTime Birthdate { get; set; }
        public bool IsPregnant { get; set; }
        public bool IsLactation { get; set; } // Süt verme döneminde mi ?


    }
}
