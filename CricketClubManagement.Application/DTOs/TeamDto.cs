namespace CricketClubManagement.Application.DTOs
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string? TeamName { get; set; } = string.Empty;
    }

    public class CreateTeamDto
    {
        public string? TeamName { get; set; } = string.Empty;
    }

    public class UpdateTeamDto
    {
        public string? TeamName { get; set; } = string.Empty;
    }

}
