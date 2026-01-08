using System;
using System.Collections.Generic;
using System.Text;

namespace CricketClubManagement.Domain.Entities
{
    public class Season
    {
        public int SeasonId { get; set; }
        public string? SeasonTitle { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }

        // Navigation properties
        public ICollection<Match>? Matches { get; set; }  // one-to-many
    }
}
