using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Models
{
    public class FootballMatch
    {
        public FootballTeam Host { get; set; }

        public FootballTeam Visitor { get; set; }

        public DateTime ScheduledDateAndTime { get; set; }

        public IQueryable<Goal>? Goals { get; set; }

        public IQueryable<Assist>? Assists { get; set; }

        public string Result { get; }

        public FootballMatch()
        {
            //TO DO: debug afterwards
            this.Result = string.Concat(
                Goals.Where(x => x.Goalscorer.FootballTeam.ID == Host.ID).Count().ToString(),
                "-",
                Goals.Where(x => x.Goalscorer.FootballTeam.ID == Visitor.ID).Count().ToString());
        }
    }
}
