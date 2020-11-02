using LotteryMVC.Hubs;
using LotteryMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryMVC.Services
{
    public class GamesService
    {
        private ILogger<GamesService> _logger;
        UserManager<User> _userManager;
        IHubContext<GameHub> _gameHub;
        IHubContext<NotificationHub> _notificationHub;
        GamesConfiguration _options;
        HistoryService _historyService;
        public GamesService(IServiceScopeFactory serviceScopeFactory,ILogger<GamesService> logger,IOptions<GamesConfiguration> options)
        {
            IServiceScope scope = serviceScopeFactory.CreateScope();
            _userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            _gameHub = scope.ServiceProvider.GetRequiredService<IHubContext<GameHub>>();
            _notificationHub = scope.ServiceProvider.GetRequiredService<IHubContext<NotificationHub>>();
            _historyService = scope.ServiceProvider.GetRequiredService<HistoryService>();
            _logger = logger;
            _options = options.Value;
            Games = new List<Game>();
            

            foreach(var conf in _options.GamesList)
            {
                CreateGame(conf);
            }
        }

        private List<Game> Games;

        public List<Game> getGames()
        {
            return Games;
        }
        public Game getGame(int Identifier)
        {
            if((Identifier >= 0) &&(Identifier < Games.Count))
            {
                return Games[Identifier];
            }
            else
            {
                return null;
            }
            
        }
        
        public List<GameViewModel> getViewModels()
        {
            List<GameViewModel> list = new List<GameViewModel>();
            foreach(var obj in Games)
            {
                list.Add(obj.getViewModel());
            }
            return list;
        }
        

        public Game CreateGame(GameViewModel model = null)
        {
            int newIdentifier = Games.Count;

            Game newGame = new Game(_userManager, _gameHub, _notificationHub, newIdentifier, _historyService, model);
            Games.Add(newGame);
            _logger.LogInformation("Create new Game : " + newIdentifier);
            return newGame;
        }

        public DeleteGameResult DeleteGame(int Identifier)
        {
            if ((Identifier >= 0) && (Identifier < Games.Count))
            {
                Game game = Games[Identifier];
                if(!game.isStarted())
                {
                    _gameHub.Clients.Group(game.getViewModel().Identifier.ToString()).SendAsync("GameDelete");
                    Games.RemoveAt(Identifier);
                    return DeleteGameResult.Ok;
                }else
                {
                    return DeleteGameResult.GameStarted;
                }

            }
            else
            {
                return DeleteGameResult.NoGame;
            }
            
        }
    }

    public enum DeleteGameResult
    {
        Ok,
        GameStarted,
        NoGame
    }
}
