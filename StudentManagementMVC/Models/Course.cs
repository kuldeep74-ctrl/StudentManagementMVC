using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementMVC.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
