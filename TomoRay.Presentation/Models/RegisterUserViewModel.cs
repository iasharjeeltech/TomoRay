using System.ComponentModel.DataAnnotations;
using TomoRay.Domain.Static;

namespace TomoRay.Presentation.Models
{
    public class RegisterUserViewModel
    {
        [Required]
        public UserRole Role { get; set; }

        [Required]
        public string FullName { get; set; } // 👈 Rename Name → FullName

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } // 👈 Add PhoneNumber

        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
