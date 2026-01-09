using System.ComponentModel.DataAnnotations;

namespace CricketClubManagement.Application.DTOs
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; } = string.Empty;
    }

    public class CreateRoleDto
    {
        [Required]
        [MaxLength(15, ErrorMessage = "Role Must be less than 15 letters")]
        public string? RoleName { get; set; } = string.Empty;
    }

    public class UpdateRoleDto
    {
        [Required]
        [MaxLength(15)]
        public string? RoleName { get; set; } = string.Empty;
    }

}
