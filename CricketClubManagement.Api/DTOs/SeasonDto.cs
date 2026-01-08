namespace CricketClubManagement.Api.DTOs
{
    public class SeasonDto
    {
        public int SeasonId { get; set; }
        public string? SeasonTitle { get; set; }
        public DateTime SeasonStartDate { get; set; }

        public DateTime SeasonEndDate { get; set; }
    }
    public class CreateSeasonDto
    {
        public string? SeasonTitle { get; set; }
        public DateTime SeasonStartDate { get; set; }

        public DateTime SeasonEndDate { get; set; }
    }

    public class UpdateSeasonDto
    {
        public string? SeasonTitle { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }

    }
    public class DeleteSeasonDto
    {
        public int SeasonId { get; set; }
    }
}