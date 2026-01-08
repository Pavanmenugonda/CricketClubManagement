namespace CricketClubManagement.Api.DTOs
{
    public class TeamSeasonDto
    {
        public int TeamSeasonId { get; set; }
        public int SeasonId { get; set; }
    }

    public class CreateTeamSeasonDto
    {
        public int TeamSeasonId { get; set; }
        public int SeasonId { get; set; }
    }

    public class UpdateTeamSeasonDto
    {
        public int TeamSeasonId { get; set; }
        public int SeasonId { get; set; }
    }
   
    public class DeleteTeamSeasonDto
    {
        public int TeamSeasonId { get; set; }

     }
}
