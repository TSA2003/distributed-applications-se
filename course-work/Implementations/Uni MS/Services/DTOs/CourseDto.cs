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
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
    }
}
