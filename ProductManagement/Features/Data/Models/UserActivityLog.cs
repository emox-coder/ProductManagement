using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Features.Data.Models
{
    public class UserActivityLog
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required, MaxLength(100)]
        public string Username { get; set; } = string.Empty;
        
        [Required, MaxLength(50)]
        public string Action { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string? Description { get; set; }
        
        [MaxLength(100)]
        public string? IpAddress { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation property
        public User? User { get; set; }
    }
}
