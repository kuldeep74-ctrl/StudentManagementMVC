using Microsoft.AspNetCore.Mvc;
using StudentManagementMVC.Data;
using StudentManagementMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentManagementMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(
                _context.Departments,
                "Id",
                "DepartmentName"
            );

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(student);
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                                         .Include(s => s.Department)
                                         .ToListAsync();

            return View(students);
        }

        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            ViewBag.Departments = new SelectList(
                _context.Departments,
                "Id",
                "DepartmentName",
                student.DepartmentId
            );

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Adults()
        {
            var students = _context.Students
                                   .Where(s => s.Age >= 18)
                                   .ToList();

            return View(students);
        }
        public IActionResult Search()
        {
            var student = _context.Students
                                  .FirstOrDefault(s => s.Name == "Kuldeep");

            return View(student);
        }
        public IActionResult SortByName()
        {
            var students = _context.Students
                                   .OrderBy(s => s.Name)
                                   .ToList();

            return View(students);
        }
        public IActionResult SortByAge()
        {
            var students = _context.Students
                                   .OrderByDescending(s => s.Age)
                                   .ToList();

            return View(students);
        }
        public IActionResult SortByAgeAscending()
        {
            var students = _context.Students
                                   .OrderBy(s => s.Age)
                                   .ToList();

            return View(students);
        }

        public IActionResult CheckStudent()
        {
            bool exists = _context.Students
                                  .Any(s => s.Name == "Kuldeep");

            if (exists)
            {
                return Content("Student Exists");
            }

            return Content("Student Not Found");
        }
    }
}
