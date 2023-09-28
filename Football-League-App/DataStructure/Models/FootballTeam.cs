using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Models
{
    public class FootballTeam : BaseEntity
    {
        public string Name { get; set; }

        public int Points { get; set; }

        public string Stadium { get; set; }

        public virtual FootballLeague FootballLeague { get; set; }

        public virtual IQueryable<FootballPlayer> FootballPlayers { get; set; }

        [NotMapped]
        public virtual IQueryable<FootballMatch> FootballMatches { get; set; }
    }
}
