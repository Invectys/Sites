using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotteryMVC.Services;
using Microsoft.AspNetCore.Mvc;
using LotteryMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LotteryMVC.Controllers
{
    public class GamesController : Controller
    {
        GamesService _gamesService;
        UserManager<User> _userManager;

        public GamesController(GamesService gamesService,UserManager<User> userManager)
        {
            _gamesService = gamesService;
            _userManager = userManager;
        }

        public IActionResult Index(int page = 1,int RateMin = 0,int RateMax = 0)
        {
            if (page < 1) return NotFound();

            int GamesCountOnPage = 5;

            List<GameViewModel> games = _gamesService.getViewModels();
            
            if(RateMax != 0)
            {
                games = games.Where(g => (g.Rate <= RateMax) && (g.Rate >= RateMin)).ToList();
            }
            var count = games.Count();
            var items = games.Skip((page - 1) * GamesCountOnPage).Take(GamesCountOnPage).ToList();


            PageViewModel pageViewModel = new PageViewModel(count, page, GamesCountOnPage);
            GameListViewModel viewModel = new GameListViewModel
            {
                PageViewModel = pageViewModel,
                Games = items,
                RateMin = RateMin,
                RateMax = RateMax
            };

            return View(viewModel);
        }

        public IActionResult Game(int Identifier = -1)
        {
            Game game = _gamesService.getGame(Identifier);
            if (game == null) return StatusCode(422);
            GameConfigureModel model = game.getConfigureModel();
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public  int Join(int Identifier = -1)
        {

            Game game = _gamesService.getGame(Identifier);
            if (game == null) return -1;
            JoinRules result  = game.Join(HttpContext.User).Result;

            return (int)result;


        }
        [Authorize]
        [HttpPost]
        public  int Exit(int Identifier)
        {

            Game game = _gamesService.getGame(Identifier);
            if (game == null) return -1;
            
            ExitRules result =  game.Exit(HttpContext.User).Result;

            return (int)result;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create(GameViewModel model)
        {
            _gamesService.CreateGame(model);
            return View("Index", _gamesService.getViewModels());
        }
        [Authorize(Roles ="admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int Identifier)
        {
            DeleteGameResult result = _gamesService.DeleteGame(Identifier);
            if(result == DeleteGameResult.Ok) return Index();
            return StatusCode(500);
        }
    }
}