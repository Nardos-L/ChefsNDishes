using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {

        private ChefsNDishesContext db;
        public HomeController(ChefsNDishesContext context)
        {
            db = context;
        }

        //localhost 5000
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = db.Chefs
                                .Include(c => c.Dishes)
                                .ToList();
            ViewBag.AllChefs = AllChefs;
            return View();
        }

        //localhost 5000/new
        [HttpPost("/Create/chef")]
        public IActionResult CreateChef(Chef newChef)
        {
            if (ModelState.IsValid == false)
            {
                if(newChef.Birthday >= DateTime.Today)
                {
                    ModelState.AddModelError("Birthday","Date of birth must be a past date");
                }

                // var todayYear = DateTime.Today.Year;
                // var chefYear = newChef.Birthday.Year;
                if (DateTime.Today.Year - newChef.Birthday.Year < 18)
                {
                    ModelState.AddModelError("Birthday","Chef must be 18 year old or older");
                }
                return View("NewChef");
            }

            db.Chefs.Add(newChef);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/Add/chef")]
        public IActionResult AddChef()
        {
            return View("NewChef");
        }
    }
}
