using Lottery.Games;
using Lottery.Hubs;
using Lottery.Interfaces;
using Lottery.Models;
using Lottery.Other;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Hubs
{
    public class GameHub : Hub
    {
        ChatValidator chatValidator;
        UserManager<ApplicationUser> _userManager;
        IGamesControl _gamesControl;
        IHubSender _hubSender;

       

        public GameHub(IGamesControl  GamesControl,IHubSender hubSender, UserManager<ApplicationUser> UserManager)
        {
            chatValidator = new ChatValidator();

            _hubSender = hubSender;
            _userManager = UserManager;
            _gamesControl = GamesControl;




        }
        public override Task OnConnectedAsync()
        {
            
           
            return base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            
            await base.OnDisconnectedAsync(exception);
        }

        [Authorize]
        public async Task SendMessage(string message)
        {
            if(Context.User.Identity.IsAuthenticated)
            {
                
               if (chatValidator.isAllowed(Context.User.Identity.Name, message) && Context.Items.ContainsKey("GameID"))
                { 
                    await Clients.Group((string)Context.Items["GameID"]).SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
                }
                
                
            }
            
        }
        public async Task GameConfigure(int GameID)
        {
            
            Context.Items.TryAdd("GameID", GameID.ToString());
            await Groups.AddToGroupAsync(Context.ConnectionId, GameID.ToString());
            await Clients.Caller.SendAsync("GameConfigure", _gamesControl.GetGame(GameID).getGameInfo());
        }

        [Authorize]
        public async Task Join(int GameID)
        {
            GameJoinExceptions er = _gamesControl.GetGame(GameID).JoinGame(Context.GetHttpContext()).Result;
           if (er == GameJoinExceptions.NoException)
           {
                if(Context.Items.ContainsKey("GameID"))
                {
                    await Clients.Group((string)Context.Items["GameID"]).SendAsync("PlayerJoined", Context.User.Identity.Name);
                }
             
           }
           else
            {
                await Clients.Caller.SendAsync("Error","JoinException", er);
            }

        }

        
    }

    
    


}

