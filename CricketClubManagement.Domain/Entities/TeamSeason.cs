using System;
using System.Collections.Generic;
using System.Text;

namespace CricketClubManagement.Domain.Entities
{
    public class TeamSeason
    {
        public int TeamId { get; set; }
        public int SeasonId { get; set; }

        // Navigation properties
        public Team? Team { get; set; }
        public Season? Season { get; set; } 
    }
}
