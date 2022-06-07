using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AssignmentDbContext _context;
        public DepartmentController(AssignmentDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Departments.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            var Department = _context.Departments.ToList();
            ViewBag.Department = new SelectList(Department, "DepartmentId", "Name");

            if (id == 0)
            {
                return PartialView("_AddDepartment");
            }
            else
            {
                var department = _context.Employees.Find(id);
                return PartialView("_AddDepartment", department);
            }
        }
        [HttpPost]
        public IActionResult Add(Department model)
        {
            {
                if (model.DepartmentId == 0)
                {
                    _context.Departments.Add(model);
                    _context.SaveChanges();
                    return PartialView("_AddDepartment");
                }
                else
                {
                    return PartialView("_AddDepartment");
                }
            }
        }
    }
}
