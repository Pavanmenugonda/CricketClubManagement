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

        // Navigation properties
        public Season? Season { get; set; }  // many-to-one
        
    }
}
