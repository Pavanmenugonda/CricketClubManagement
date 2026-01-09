using System.ComponentModel.DataAnnotations;

namespace CricketClubManagement.Application.DTOs
{
    public class MatchDto
    {
        public int MatchId { get; set; }
        public string? MatchName { get; set; }
        public DateTime? MatchDate { get; set; }

        public int SeasonId { get; set; }
    }

    public class CreateMatchDto
    {
        [Required]
        [MaxLength(50)]
        public string MatchName { get; set; } = string.Empty;

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public int SeasonId { get; set; }
    }

    public class UpdateMatchDto
    {
        [Required]
        [MaxLength(50)]
        public string MatchName { get; set; } = string.Empty;

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public int SeasonId { get; set; }

    }
}
