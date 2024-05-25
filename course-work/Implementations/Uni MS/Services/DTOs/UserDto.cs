using System.ComponentModel.DataAnnotations;

namespace Services.DTOs
{
    public class UserDto : BaseDto
    {
        [Required]
        public string Username { get; set; }

        public string Token { get; set; }
    }
}
