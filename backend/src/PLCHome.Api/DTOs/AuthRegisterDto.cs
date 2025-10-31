using System.ComponentModel.DataAnnotations;

namespace PLCHome.Api.DTOs
{
    public class AuthRegisterDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required, MinLength(6)]
        public string Password { get; set; } = null!;
    }
}
