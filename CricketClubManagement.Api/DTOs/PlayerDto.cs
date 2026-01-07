namespace CricketClubManagement.Api.DTOs
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string? PlayerName { get; set; } = string.Empty;
        public int PlayerAge { get; set; }
        public string? PlayerContact { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }

    public class CreatePlayerDto
    {
        public string PlayerName { get; set; } = string.Empty;
        public int PlayerAge { get; set; }
        public string PlayerContact { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }

    public class UpdatePlayerDto
    {
        public string PlayerName { get; set; } = string.Empty;
        public int PlayerAge { get; set; }
        public string PlayerContact { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }

}
