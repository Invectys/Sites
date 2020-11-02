using Lottery.Models;
using Lottery.Other;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Interfaces
{
    
    public interface IGame
    {
       
       Task<bool> _StartGame();
       void EndGame(object o);
       
       Task<GameJoinExceptions> JoinGame(HttpContext context);


        Task<bool> AddPlayer(ApplicationUser user);
        List<string> getPlayers();
        GameInfoModel getGameInfo();
        int getTimeRemaining();
        bool GameStarted();
        int GetGameFakeLevel();
        int GetMaxBotsCount();
        int GetMaxPlayers();
        string GetID();
        void setBotControl(BotControl botControl);
        
    }
}
