using Lottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Interfaces
{
    public interface IGamesControl
    {
        void CreateNewGame(GameCreateModel configuration);
        List<Game> GetGames();
        List<GameInfoModel> GetGamesInfo();
        List<GameInfoMinModel> GetGamesInfoMin();
        Game GetGame(int GameID);
       
        
    }
}
