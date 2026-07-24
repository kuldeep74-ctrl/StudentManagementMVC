using Microsoft.AspNetCore.Mvc;
using StudentManagementMVC.Data;
using StudentManagementMVC.Models;
using Microsoft.EntityFrameworkCore;

public class DepartmentController : Controller
{
    private readonly AppDbContext _context;

    public DepartmentController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Department department)
    {
        if (!ModelState.IsValid)
        {
            return View(department);
        }

        _context.Departments.Add(department);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Index()
    {
        var departments = await _context.Departments.ToListAsync();

        return View(departments);
    }
}