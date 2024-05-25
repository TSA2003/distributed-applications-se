using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }

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

        [ValidateNever]
        public string TeacherFirstName { get; set; }

        [ValidateNever]
        public string TeacherLastName { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public List<TeacherViewModel> AvailableTeachers { get; set; }
    }
}
