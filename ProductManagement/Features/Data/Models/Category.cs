using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductManagement.Features.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
    }
}
