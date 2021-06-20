using System;
using System.Collections.Generic;
using System.Linq;
using ChefsNDishes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class DishesController : Controller
    {
        private ChefsNDishesContext db;
        public DishesController(ChefsNDishesContext context)
        {
            db = context;
        }

        //localhost:5000/dishes
        [HttpGet("/dishes")]
        public IActionResult ViewDishes()
        {
            List<Dish> AllDishes = db.Dishes
                                    .Include(d => d.Cook)
                                    .ToList();
            ViewBag.AllDishes = AllDishes;
            return View("ViewDishes");

        }

        [HttpGet("/Add/dish")]
        public IActionResult AddDish()
        {
            List<Chef> AllChefs = db.Chefs.ToList();
            ViewBag.AllChefs = AllChefs;
            return View("CreateDish");
        }

        [HttpPost("/dishes/create")]
        public IActionResult Create(Dish newDish)
        {
            if (ModelState.IsValid == false)
            {
                // Send back to the page with the form to show errors.
                return View("CreateDish");
            }
            // ModelState IS valid...
            Console.WriteLine($"{newDish.Calories}  : {newDish.Name}: {newDish.Description} {newDish.Tastiness}");

            db.Dishes.Add(newDish);
            db.SaveChanges();
            return RedirectToAction("ViewDishes");
        }




    }
}