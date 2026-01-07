using System;
using System.Collections.Generic;
using System.Text;

namespace CricketClubManagement.Domain.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string? PlayerName { get; set; }
        public int PlayerAge { get; set; }
        public string? PlayerContact { get; set; }
        public int RoleId { get; set; }

        // Navigation properties
        public Role? Role { get; set; }  // many-to-one
        public ICollection<PlayerMatch> PlayerMatches { get; set; } = new List<PlayerMatch>();  // many-to-many via PlayerMatch
        public ICollection<Fee> Fees { get; set; } = new List<Fee>(); // one-to-many
    }

}