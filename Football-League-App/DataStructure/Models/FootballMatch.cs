using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Models
{
    public class FootballMatch : BaseEntity
    {
        public virtual FootballTeam Host { get; set; }

        public virtual FootballTeam Visitor { get; set; }

        public DateTime ScheduledDateAndTime { get; set; }

        public virtual List<Goal>? Goals { get; set; } = new List<Goal>();

        public virtual List<Assist>? Assists { get; set; } = new List<Assist>();

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
