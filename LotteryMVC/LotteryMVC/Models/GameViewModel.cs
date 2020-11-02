using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace LotteryMVC.Models
{
    public class GameViewModel
    {
        public int Identifier { get; set; }
        public int PlayersNum { get; set; }
        public int NeedPlayers { get; set; }
        public int Rate { get; set; }
        public bool NeedPhoneConfirmed { get; set; }
    }
    
    public class GameConfigureModel : GameViewModel
    {
        public List<User> Players { get; set; }
        public int TimeToEnd { get; set; }
        public int TimeGameProcess { get; set; }
    }

    public class GameFullModel : GameConfigureModel
    {
        public GameFullModel()
        {
            Players = new List<User>();
            
        }

        
        public Timer TimerToEnd { get; set; }
        public bool InProcess { get; set; }
        
        public DateTime TimerStartDate { get; set; }

        public GameViewModel getViewModel() => this;
        public GameConfigureModel getConfigureModel()
        {
            if(InProcess)
            {
                TimeToEnd = TimeGameProcess - (int)(DateTime.Now - TimerStartDate).TotalMilliseconds;
            }
            else
            {
                TimeToEnd = -1;
            }
            
            return this;
        }

       public void AddPlayer(User newPlayer)
       {
            Players.Add(newPlayer);
            PlayersNum = Players.Count();
           
       }
        public void RemovePlayer(User Player)
        {
            User inUser = Players.Find(o => o.UserName == Player.UserName);
            Players.Remove(inUser);
            PlayersNum = Players.Count();
            
        }
        public void RemovePlayer(int ind)
        {
            Players.RemoveAt(ind);
            PlayersNum = Players.Count();
        }
        public void RemoveAllPlayers()
        {
            Players.Clear();
            PlayersNum = 0;
        }
    }
}
