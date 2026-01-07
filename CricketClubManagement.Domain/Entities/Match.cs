using System;
using System.Collections.Generic;
using System.Text;

namespace CricketClubManagement.Domain.Entities
{
    public class Match
    {
        public int MatchId { get; set; }
        public string? MatchName { get; set; }
        public DateTime MatchDate { get; set; }

        public int SeasonId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }

        // Navigation properties
        public Season? Season { get; set; }  // many-to-one
        public Team? HomeTeam { get; set; }  // many-to-one
        public Team? AwayTeam { get; set; }  // many-to-one
        public ICollection<PlayerMatch>? PlayerMatches { get; set; }  // many-to-many via PlayerMatch
    }
}
