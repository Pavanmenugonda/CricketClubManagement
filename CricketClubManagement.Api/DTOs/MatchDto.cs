namespace CricketClubManagement.Api.DTOs
{
    public class MatchDto
    {
        public int MatchId { get; set; }
        public string? MatchName { get; set; }
        public DateTime? MatchDate { get; set; }
    }

    public class CreateMatchDto
    {
        public string MatchName { get; set; } = string.Empty;
        public DateTime MatchDate { get; set; }
    }

    public class UpdateMatchDto
    {
        public string MatchName { get; set; } = string.Empty;
        public DateTime MatchDate { get; set; }

    }
}
