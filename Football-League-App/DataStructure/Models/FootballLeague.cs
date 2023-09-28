using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Models
{
    public class FootballLeague : BaseEntity
    {
        public IQueryable<FootballTeam> FootballTeams { get; set; }
    }
}
