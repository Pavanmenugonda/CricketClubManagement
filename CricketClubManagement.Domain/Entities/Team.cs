using System;
using System.Collections.Generic;
using System.Text;

namespace CricketClubManagement.Domain.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string? TeamName { get; set; }

        // Navigation properties
        public ICollection<Match> HomeMatches { get; set; } = new List<Match>(); // one-to-many
        public ICollection<Match> AwayMatches { get; set; } = new List<Match>();  // one-to-many
    }

}