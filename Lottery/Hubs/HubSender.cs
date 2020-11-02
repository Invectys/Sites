using Lottery.Interfaces;
using Lottery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Hubs
{
    public class HubSender : IHubSender
    {
        IGame _game;
        IHubContext<GameHub> hubContext;
        ILogger<HubSender> _logger;
        public HubSender(ILogger<HubSender> Logger,  IHubContext<GameHub> hubContext)
        {
            _logger = Logger;
            this.hubContext = hubContext;
            



        }
        public async void EndGameServerEvent(ApplicationUser winer,string GameID)
        {
            
            await hubContext.Clients.Group(GameID).SendAsync("EndGame", winer.UserName);
        }
        public async void StartGameServerEvent(string GameID)
        {
            await hubContext.Clients.Group(GameID).SendAsync("StartGame");
        }
        public async void PlayerJoined(string name,string GameID)
        {
            await hubContext.Clients.Group(GameID).SendAsync("PlayerJoined", name);
           
        }

        public async void Gameupdated(string GameID, Gameupdate update_info)
        {
            await hubContext.Clients.Group(GameID).SendAsync("Gameupdated", update_info);

        }
    }
}
