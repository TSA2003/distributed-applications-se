using System.ComponentModel.DataAnnotations;

namespace Services.DTOs
{
    public class UserDto : BaseDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
