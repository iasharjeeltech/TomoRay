using System.ComponentModel.DataAnnotations;

namespace TomoRay.Presentation.Models
{
    public class LoginUserViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
