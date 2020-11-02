using Lottery.Interfaces;
using Lottery.Models;
using Lottery.Other;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Games
{
    public class GamesStore
    {
        UserManager<ApplicationUser> _userManager;

        private readonly ILogger<IGame> _logger;
        private readonly IHubSender hubSender;
        private readonly LotteryOptions lotteryOptions;
        FakeControl _fakeControl;

        //public List<int> UsersInRooms = new List<int>();
        public List<Game> Games = new List<Game>();

        public GamesStore(ILogger<IGame> Logger, IHubSender hubSender, FakeControl fakeControl,
            IServiceScopeFactory ScopeFactory, IOptionsMonitor<LotteryOptions> optionsMonitor)
        {
            IServiceScope Scope = ScopeFactory.CreateScope();
            _userManager = Scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

            this.hubSender = hubSender;
            _fakeControl = fakeControl;
            _logger = Logger;
            lotteryOptions = optionsMonitor.CurrentValue;
        }

        public void CreateGame(GameCreateModel info)
        {
            
            Game game = new Game(_logger, hubSender, _userManager, info, lotteryOptions, _fakeControl);
            Games.Add(game);
        }

        public List<Game> GetGames()
        {
            return Games;
        }

       
    }
}
