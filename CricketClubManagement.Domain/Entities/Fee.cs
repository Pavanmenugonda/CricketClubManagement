using System;
using System.Collections.Generic;
using System.Text;

namespace CricketClubManagement.Domain.Entities
{
    public class Fee
    {
        public int FeeId { get; set; }
        public DateTime FeeDate { get; set; }
        public decimal Amount { get; set; }
        public int PlayerId { get; set; }

        // Navigation property
        public Player? Player { get; set; }  // many-to-one
    }
}
