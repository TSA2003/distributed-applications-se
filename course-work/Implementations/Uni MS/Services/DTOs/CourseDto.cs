using System.ComponentModel.DataAnnotations;

namespace Services.DTOs
{
    public class CourseDto : BaseDto
    { 
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public int Points { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public Guid TeacherId { get; set; }

        public string? TeacherFirstName { get; set; }
        public string? TeacherLastName { get; set; }
    }
}
