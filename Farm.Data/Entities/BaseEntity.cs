using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data.Entities
{
    public abstract class BaseEntity
    {
        public string EaringNo { get; set; }// TR 06 1234
        public DateTime BirthDate { get; set; }
    }
}
