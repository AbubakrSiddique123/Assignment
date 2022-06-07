using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    public class UserController : Controller
    {
        private readonly AssignmentDbContext _context;
        public UserController(AssignmentDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
           var result = _context.Users.Where(x => x.UserName == u.UserName && x.Password == u.Password).FirstOrDefault();
            return RedirectToAction("Index", "Employee");
        }

    }
}
