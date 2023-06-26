using System.ComponentModel.DataAnnotations;

namespace MyApp.DTOs.Users
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email is require!")]
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
