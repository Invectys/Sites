using Lottery.Interfaces;
using Lottery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lottery.Games
{
    public  class GamesControl : IGamesControl
    {
        ILogger<IGame> _logger;
        UserManager<ApplicationUser> _userManager;
        GamesStore _gamesStore;
        private readonly LotteryOptions lotteryOptions;
        

        public GamesControl(ILogger<IGame> Logger, UserManager<ApplicationUser> userManager, 
            IHubSender hubSender, IServiceScopeFactory ScopeFactory, IOptionsMonitor<LotteryOptions> optionsMonitor)
        {
            IServiceScope Scope = ScopeFactory.CreateScope();
            _gamesStore = Scope.ServiceProvider.GetService<GamesStore>();
            lotteryOptions = optionsMonitor.CurrentValue;


            _userManager = userManager;
            _logger = Logger;
        }

        public void CreateNewGame(GameCreateModel configuration)
        {
            configuration.GameID = _gamesStore.GetGames().Count.ToString();
            _gamesStore.CreateGame(configuration);
        }

        public Game GetGame(int GameID)
        {

            return _gamesStore.Games.ElementAtOrDefault(GameID);
        }
        public List<Game> GetGames()
        {
            return _gamesStore.GetGames();
        }

        public List<GameInfoModel> GetGamesInfo()
        {
            List<Game> games = _gamesStore.GetGames();
            List<GameInfoModel> infoModels = new List<GameInfoModel>();
            foreach(var i in games)
            {
                infoModels.Add(i.getGameInfo());
            }
            return infoModels;
        }

        public List<GameInfoMinModel> GetGamesInfoMin()
        {
            List<Game> games = _gamesStore.GetGames();
            List<GameInfoMinModel> infoModels = new List<GameInfoMinModel>();
            foreach (var i in games)
            {
                infoModels.Add(i.getGameInfoMin());
            }
            return infoModels;
        }

        public void RemoveGame(object Game)
        {
            Game game = (Game)Game;
            game.Onupdated = true;
            if (game.GameStarted())
            {
                TimerCallback tm = new TimerCallback(RemoveGame);
                Timer timer1 = new Timer(tm, game, (game.GameTime - game.getTimeRemaining() + 1) * 1000, -1);
                return;
            }
            game._hubSender.Gameupdated(game.GetID(), Gameupdate.GameDeleted);
            _gamesStore.Games.Remove(game);
        }
        
    }


   
}
