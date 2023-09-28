using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Models
{
    public class FootballLeague : BaseEntity
    {
        public string Name { get; set; }

        public virtual IQueryable<FootballTeam> FootballTeams { get; set; }
    }
}
