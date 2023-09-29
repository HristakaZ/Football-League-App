namespace Football_League_App.DTOs.FootballMatch
{
    public class CreateFootballMatchDTO
    {
        public int[] HostAndVisitorIDs { get; set; }

        public DateTime ScheduledDateAndTime { get; set; }

        public string? EndResult { get; set; }
    }
}
