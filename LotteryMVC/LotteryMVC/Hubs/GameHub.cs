using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryMVC.Hubs
{
    public class GameHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }



        public async void AddToGroup(int identifier)
        {
            string str = identifier.ToString();
            await Groups.AddToGroupAsync(Context.ConnectionId, str);
        }

        

        
        
    }
}
