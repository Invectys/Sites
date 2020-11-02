using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lottery.Models;
using Lottery.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using Lottery.Data;
using Microsoft.EntityFrameworkCore;
using Lottery.Models.Enums;

namespace Lottery.Controllers
{
    public class HomeController : Controller
    {
        IGamesControl GamesControl;
        UserManager<ApplicationUser> _UserManager;
        MainOptions opt;
        

        public HomeController(IGamesControl games, UserManager<ApplicationUser> UserManager,
            IOptionsMonitor<MainOptions> OptionsAccessor, IOptionsMonitor<LotteryOptions> pOptionsAccessor)
        {
            GamesControl = games;
            _UserManager = UserManager;
            
            opt = OptionsAccessor.CurrentValue;
        }

        public async Task<IActionResult> Find(string name)
        {

            IQueryable<ApplicationUser> users = _UserManager.Users;
            
            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.UserName.Contains(name));


                //users = users.Where(p => p.UserName.Contains(name));
            }

  
            UsersListViewModel viewModel = new UsersListViewModel
            {
                Users = users.ToList(),
                Name = name
            };

            return View(viewModel);
        }
        
        public  IActionResult Index()
        {
            //ViewBag.Games = GamesControl.GetGamesInfoMin();
            //ViewBag.User = HttpContext.User.Identity.Name;
            //ViewBag.Players = game.getPlayers();

            //if(HttpContext.Request.Cookies.ContainsKey("visit"))
            //{
                
            //    return LocalRedirect("~/News/Index");
            //}
            //HttpContext.Response.Cookies.Append("visit", "1");

            return View();
        }
        public IActionResult Preview(string path = "")
        {
            ViewBag.path = path;

            return View();
        }
        public IActionResult Games()
        {
            ViewBag.Games = GamesControl.GetGamesInfoMin();
            ViewBag.User = HttpContext.User.Identity.Name;
            //ViewBag.Players = game.getPlayers();

            return View("Games");
        }

        public IActionResult Game(int GameID)
        {
            Game game = GamesControl.GetGame(GameID);
            if(game != null)
            {
                ViewBag.User = HttpContext.User.Identity.Name;
                ViewBag.Players = game.getPlayers();
                ViewBag.Rate = game.Rate;
                ViewBag.GameID = GameID;
                return View("Game");
            }
            else
            {
                return StatusCode(404);
            }
           
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            
        }



        public IActionResult Create()
        {
            return View("Index");
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
                return Content($"{person.Name} - {person.Email}");
            else
                return View(person);
        }

    }


    public class Person
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int Age { get; set; }
    }
}
