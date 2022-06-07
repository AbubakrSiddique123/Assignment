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
    public class EmployeeController : Controller
    {
        private readonly AssignmentDbContext _context;
        public EmployeeController(AssignmentDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Employees.Include(d => d.Designation).Include(d => d.Department).ToList();
            return View(list);
          
        }
        [HttpGet]
        public IActionResult AddorEdit(int id)
        {
            var Designation = _context.Designations.ToList();
            ViewBag.Designation = new SelectList(Designation, "DesignationId", "Name");
            var Department = _context.Departments.ToList();
            ViewBag.Department = new SelectList(Department, "DepartmentId", "Name");
            if (id == 0)
            {
                return PartialView("_AddOrEdit");
            }
            else
            {
                var Employee = _context.Employees.Find(id);
                return PartialView("_AddOrEdit", Employee);
            }
        }
        [HttpPost]
        public IActionResult AddorEdit(Employee model)
        {
            {
                if (model.EmployeeId == 0)
                {
                    _context.Employees.Add(model);
                    _context.SaveChanges();
                    return PartialView("_AddorEdit");
                }
                else
                {
                    _context.Employees.Update(model);
                    _context.SaveChanges();
                    return PartialView("_AddorEdit");
                }
            }
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var a = await _context.Employees.FindAsync(Id);
            _context.Employees.Remove(a);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool EmployeeExists(int Id)
        {
            return _context.Employees.Any(e => e.EmployeeId == Id);
        }
    }
}
