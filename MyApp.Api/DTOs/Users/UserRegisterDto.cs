using System.ComponentModel.DataAnnotations;

namespace MyApp.DTOs.Users
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Email is required!")]
        public string? Email { get; set; }

        public string? Password { get; set; }

        [Required(ErrorMessage = "UserName is required!")]
        public string? UserName { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
