using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }  // In Farm, Sale, Died ...
        public string EaringNo { get; set; }// TR 06 1234
        public DateTime? BirthDate { get; set; }
        public string Name { get; set; }
        public virtual State State { get; set; }
    }
}
