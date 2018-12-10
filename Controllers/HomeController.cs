using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ChefsNDishes.Models;
using System.Linq;
using System.Data.Entity;


namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefsNDishesContext dbContext;
        public HomeController(ChefsNDishesContext context)
        {
        dbContext = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chef.ToList();
            
            var AllChefsWithDishes = dbContext.Dish
            .Include(dish => dish.ChefWhoMade).ToList();

            ViewBag.Url = Request.HttpContext.Request.Path.ToString();

            var Today = DateTime.Today;
            foreach(var chef in AllChefs)
            {
                chef.Age = Today.Year - chef.BirthDate.Year;
                
            }
            
            
            return View(AllChefs);
        }

        [HttpGet("dishes")]
        public IActionResult ShowDishes()
        {
            ViewBag.Url = Request.HttpContext.Request.Path.ToString();
            List<Dish>AllDishes = dbContext.Dish.ToList();
            return View(AllDishes);
        }

        
        [HttpGet("dishes/new")]
        
        public IActionResult ShowAddNewDish()
        {
            ViewBag.Url = Request.HttpContext.Request.Path.ToString();

            List<Chef> AllChefs = dbContext.Chef.ToList();
            ViewBag.AllChefs = AllChefs;
            foreach(var ac in ViewBag.AllChefs)
            {
                System.Console.WriteLine($"{ac.FirstName}(*&!(*&!(*&!(*&!(*!&(!*&!");
            }
            return View();
        }

        [HttpPost("CreateDish")]
        public IActionResult CreateDish(Dish NewDish, int FormChefId)
        {
            
            Chef ChefSelected = dbContext.Chef.FirstOrDefault(c => c.ChefId == FormChefId);
            NewDish.ChefId = FormChefId;
            dbContext.Add(NewDish);
            dbContext.SaveChanges();
            

            return RedirectToAction("ShowDishes");
        }

        [HttpGet("new")]
        public IActionResult ShowAddChef()
        {
            return View();
        }

        [HttpPost("AddChef")]
        public IActionResult AddChef(Chef NewChef)
        {
            dbContext.Add(NewChef);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
