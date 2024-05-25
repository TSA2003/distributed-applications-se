using System.ComponentModel.DataAnnotations;

namespace Services.DTOs
{
    public class StudentDto : BaseDto
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        public double AverageGrade { get; set; }

        public Guid CourseId { get; set; }
        public string? CourseName { get; set; }
    }
}
