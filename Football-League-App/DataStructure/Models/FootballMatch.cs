using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Models
{
    public class FootballMatch : BaseEntity
    {
        public DateTime ScheduledDateAndTime { get; set; }

        public virtual List<FootballTeam> FootballTeams { get; set; } = new List<FootballTeam>();

        public string EndResult { get; set; }
    }
}
