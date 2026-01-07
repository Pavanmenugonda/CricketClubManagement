using System;
using System.Collections.Generic;
using System.Text;

namespace CricketClubManagement.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        // Navigation property
        public ICollection<Player>? Players { get; set; }  // one-to-many
    }
}
