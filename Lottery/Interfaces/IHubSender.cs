using Lottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Interfaces
{
    public interface IHubSender
    {
       void EndGameServerEvent(ApplicationUser winer, string GameID);
       void StartGameServerEvent(string GameID);
       void PlayerJoined(string name, string GameID);
       void Gameupdated(string GameID, Gameupdate update_info);
    }
}
