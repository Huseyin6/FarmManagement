using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Entities
{
    public class Cattle
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }  // In Farm, Sale, Died ...
        public string EaringNo { get; set; }// TR 06 1234
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public int CattleTypeId { get; set; }
        public bool IsPregnant { get; set; }
        public bool IsLactation { get; set; }
        [UIHint("SexView")]
        [Display(Name="Cinsiyet")]
        public int Sex { get; set; }
        public bool DrinkMilk { get; set; } // Does He/She Drink Milk (this prop is only calves) ?

        public virtual CattleType CattleType { get; set; }
        public virtual State State { get; set; }
    }
}
