using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }

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

        [ValidateNever]
        public string CourseName { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public List<CourseViewModel> AvailableCourses { get; set; }
    }
}
