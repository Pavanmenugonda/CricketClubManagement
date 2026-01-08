namespace CricketClubManagement.Api.DTOs
{
    public class FeeDto
    {
        public int FeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime FeeDate { get; set; }
        public int PlayerId { get; set; }
    }
    public class CreateFeeDto
    {
        public decimal Amount { get; set; }
        public DateTime FeeDate { get; set; }

        public int PlayerId { get; set; }
    }

    public class UpdateFeeDto
    {
        public decimal Amount { get; set; }

        public DateTime FeeDate { get; set; }

        public int PlayerId { get; set; }
    }
}
