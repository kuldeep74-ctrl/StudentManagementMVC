using System.ComponentModel.DataAnnotations;

namespace StudentManagementMVC.Models
{
    public class Student 
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [StringLength(50, MinimumLength =3)]
        public string Name { get; set; }

        [Range(15, 70, ErrorMessage ="Age must be between 15 to 70")]
        public int Age { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}

