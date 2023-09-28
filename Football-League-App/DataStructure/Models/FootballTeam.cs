using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Models
{
    public class FootballTeam : BaseEntity
    {
        public int Points { get; set; }

        public FootballLeague FootballLeague { get; set; }

        public IQueryable<FootballPlayer> FootballPlayers { get; set; }

        public IQueryable<FootballMatch> FootballMatches { get; set; }
    }
}
