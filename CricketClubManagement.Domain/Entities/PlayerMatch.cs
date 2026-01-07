using System;
using System.Collections.Generic;
using System.Text;

namespace CricketClubManagement.Domain.Entities
{
    public class PlayerMatch
    {
        public int PlayerId { get; set; }
        public int MatchId { get; set; }

        public int? RunsScored { get; set; }
        public int? WicketsTaken { get; set; }
        public int? Catches { get; set; }

        // Navigation properties
        public Player? Player { get; set; }
        public Match? Match { get; set; }
    }
}
