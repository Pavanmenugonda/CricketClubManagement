using System.ComponentModel.DataAnnotations;

namespace CricketClubManagement.Application.DTOs
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
        [Required]
        [MaxLength(50)]
        public string PlayerName { get; set; } = string.Empty;

        [Required]
        [Range(10, 70, ErrorMessage = "Player age must be between 10 and 70.")]
        public int PlayerAge { get; set; }

        [Required]
        [Phone(ErrorMessage = "PlayerContact must be a valid phone number.")]
        [MaxLength(10)]
        public string PlayerContact { get; set; } = string.Empty;

        [Required]
        public int RoleId { get; set; }
    }

    public class UpdatePlayerDto
    {
        [Required]
        [MaxLength(50)]
        public string PlayerName { get; set; } = string.Empty;

        [Required]
        [Range(10, 70, ErrorMessage = "Player age must be between 10 and 70.")]
        public int PlayerAge { get; set; }

        [Required]
        [Phone(ErrorMessage = "PlayerContact must be a valid phone number.")]
        [MaxLength(10)]
        public string PlayerContact { get; set; } = string.Empty;

        [Required]
        public int RoleId { get; set; }
    }

}
