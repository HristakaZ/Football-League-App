using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Models
{
    public class Goal : BaseEntity
    {
        public virtual FootballPlayer Goalscorer { get; set; }
    }
}
