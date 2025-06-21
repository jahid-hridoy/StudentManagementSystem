using StudentManagement.Data;
using StudentManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Controllers;


public class StudentController : Controller
{
    private readonly StudentDbContext _context;

    public StudentController(StudentDbContext context)
    {
        _context = context;
    }

    // GET: Inventory
    public  IActionResult Index(string status)
    {
        IQueryable<StudentModel> query = _context.StudentList;
        if (!string.IsNullOrEmpty(status))
        {
            query = query.Where(i => i.Status.ToString() == status);
        }
        
        var inventoryItems = query.ToList();
        return View(inventoryItems);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(StudentModel studentInfo)
    {
        if (ModelState.IsValid)
        {
            if (studentInfo.TotalMarks >= 80)
            {
                studentInfo.Status = Status.Excellent;
            }
            else if (studentInfo.TotalMarks >= 50)
            {
                studentInfo.Status = Status.Good;
            }
            else
            {
                studentInfo.Status = Status.Needs_Improvement;
            }
            _context.StudentList.Add(studentInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(studentInfo);
    }

}