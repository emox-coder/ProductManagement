using System.ComponentModel.DataAnnotations;
 
 namespace ProductManagement.Features.Data.Models
 {
     public class User
     {
         [Key]
         public int Id { get; set; }
         [MaxLength(100)]
         public string Name { get; set; } = string.Empty;
         [Required, MaxLength(100), EmailAddress]
         public string Email { get; set; } = string.Empty;
         [Required, MaxLength(20)]
         public string Username { get; set; } = string.Empty;
         [Required, MaxLength(64)]
         public string Password { get; set; } = string.Empty;
         public string Role { get; set; } = "User";
 
     }
 }
