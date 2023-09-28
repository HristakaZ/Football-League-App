using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Models
{
    public class FootballPlayer : BaseEntity
    {
        public string Name { get; set; }

        public virtual FootballTeam FootballTeam { get; set; }
    }
}
