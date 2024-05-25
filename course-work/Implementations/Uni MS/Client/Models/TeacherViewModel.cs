using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class TeacherViewModel
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

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public DateTime EmploymentDate { get; set; }

        public int Experience { get; set; }
    }
}
