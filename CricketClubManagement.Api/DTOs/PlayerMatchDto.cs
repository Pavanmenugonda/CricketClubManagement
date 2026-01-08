namespace CricketClubManagement.Api.DTOs
{
    public class PlayerMatchDto
    {
        public int PlayerId { get; set; }
        public int MatchId { get; set; }
        public int? RunsScored { get; set; }
        public int? WicketsTaken { get; set; }
        public int? Catches { get; set; }
    }

    public class CreatePlayerMatchDto
    {
        public int PlayerId { get; set; }
        public int MatchId { get; set; }
        public int RunsScored { get; set; }
        public int WicketsTaken { get; set; }
        public int Catches { get; set; }
    }
    public class UpdatePlayerMatchDto
    {
        public int PlayerId { get; set; }
        public int MatchId { get; set; }
        public int RunsScored { get; set; }
        public int WicketsTaken { get; set; }
        public int Catches { get; set; }
    }

    public class DeletePlayerMatchDto
    {
        public int PlayerMatchId { get; set; }

        public int PlayerId { get; set; }

    }
}
