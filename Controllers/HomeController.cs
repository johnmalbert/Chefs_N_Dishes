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
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllChefs = _context.Chefs.Include(c => c.CreatedDishes);
            var firstChef = _context.Chefs.First(c=>c.ChefId == 1);
            // Console.WriteLine(firstChef.CreatedDishes.Count);            
            return View();
        }

        [HttpGet("new")]
        public IActionResult AddChef()
        {
            return View();
        }

        [HttpPost("new/chef/create")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                //add chef to db
                _context.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddChef");
            }
        }
        [HttpGet("dishes/new")]
        public IActionResult AddDish()
        {
            ViewBag.AllChefs = _context.Chefs.Include(c => c.CreatedDishes);
            return View();
        }

        [HttpPost("dishes/create")]
        public IActionResult CreateDish(Dish newDish, int TheChefId)
        {
            Console.WriteLine(TheChefId);
            
            if(ModelState.IsValid)
            {
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Dishes");
            }
            return View("AddDish");
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            ViewBag.AllDishes = _context.Dishes.Include(d => d.ChefName);
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
