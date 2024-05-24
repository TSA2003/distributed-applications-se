using System.ComponentModel.DataAnnotations;

namespace Services.DTOs
{
    public class TeacherDto : BaseDto
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public DateOnly EmploymentDate { get; set; }

        public int Experience { get; set; }
    }
}
