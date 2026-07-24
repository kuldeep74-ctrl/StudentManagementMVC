using System.ComponentModel.DataAnnotations;

namespace StudentManagementMVC.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}