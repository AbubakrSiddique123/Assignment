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
    public class DesignationController : Controller
    {
        private readonly AssignmentDbContext _context;
        public DesignationController(AssignmentDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Designations.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            var Designation = _context.Designations.ToList();
            ViewBag.Designation = new SelectList(Designation, "DesignationId", "Name");

            if (id == 0)
            {
                return PartialView("_AddDesignation");
            }
            else
            {
                var designation = _context.Employees.Find(id);
                return PartialView("_AddDesignation", designation);
            }
        }
        [HttpPost]
        public IActionResult Add(Designation model)
        {
            {
                if (model.DesignationId == 0)
                {
                    _context.Designations.Add(model);
                    _context.SaveChanges();
                    return PartialView("_AddDesignation");
                }
                else
                {
                    return PartialView("_AddDesignation");
                }
            }
        }
    }
}
