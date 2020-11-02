using Lottery.Interfaces;
using Lottery.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lottery.Other
{
    public class FakeControl
    {
        LotteryOptions LotteryOptions;
        IHubSender _hubSender;
        List<string> FakeNames;
        public FakeControl(IHubSender hubSender,
            IOptionsMonitor<MainOptions> OptionsAccessor, IOptionsMonitor<LotteryOptions> pOptionsAccessor)
        {
            LotteryOptions = pOptionsAccessor.CurrentValue;
            FakeNames = new List<string>(LotteryOptions.FakeNames);
            _hubSender = hubSender;
        }

        public void AddFakeName(string name)
        {
            FakeNames.Add(name);
        }

        


        public void AddBotControl(IGame game)
        {
            BotControl BotControl = new BotControl(game, this);
            game.setBotControl(BotControl);
        }

        
        public void ReceiveNames(List<string> names)
        {
            FakeNames.AddRange(names);
        }
        public List<string> AllocateNames(int count)
        {
            List<string> names = new List<string>();
            Helpful.MixNames(FakeNames);

            while(count > 0)
            {
                string name = FakeNames.ElementAtOrDefault(0);
                if(name!= null)
                {
                    names.Add(name);
                    FakeNames.Remove(name);
                    count--;
                }
                else
                {
                    return names;
                }
                
            }

            return names;
        }
    }



    public class BotControl
    {
        public IGame Game;
       
        FakeControl fakeControl;
        List<string> FakeNames;
        int FakeLevel;

        bool Work = false;
        public BotControl(IGame game, FakeControl fakeControl)
        {
            Game = game;
            this.fakeControl = fakeControl;
            FakeLevel = game.GetGameFakeLevel();
            this.FakeNames = fakeControl.AllocateNames(Game.GetMaxBotsCount());
           

            if ((FakeLevel != 0) && (game.GetMaxBotsCount() > 0) && (game.GetMaxBotsCount() <= game.GetMaxPlayers()))
            {
                
                StartFloatFakePlayers();

                Work = true;
            }

        }
        
        public void StartFloatFakePlayers(int firsttime = -1)
        {
            Random rnd = new Random(Game.GetMaxBotsCount() + Game.GetGameFakeLevel() * 10 + (int)DateTime.Now.Ticks);

            TimerCallback tm = new TimerCallback(this.updateFakePlayers);
            Timer timer = new Timer(tm,1 , rnd.Next(5, 9) * 1000, -1);
        }

        public void updateFakePlayers(object count)
        {
            Random rnd = new Random(10 + (int)DateTime.Now.Ticks);
            bool updateNames = rnd.Next(100) < 30;
            if(updateNames)
            {
                List<string> names = new List<string>();
                Helpful.MixNames(FakeNames);
                int Count = (int)count;

                while (Count > 0)
                {
                    string name = FakeNames.ElementAtOrDefault(0);
                    if (name != null)
                    {
                        names.Add(name);
                        FakeNames.Remove(name);
                        Count--;
                    }
                    else
                    {
                        break;
                    }

                }

                FakeNames.AddRange(fakeControl.AllocateNames((int)count - Count));
                fakeControl.ReceiveNames(names);
            }
            
            new Task(() => FillGame(Game.GetMaxBotsCount())).Start();
            
        }

        public void onGameEnd(object o = null)
        {
            if (Work)
            {
               
               //...
            }
        }

            
      

        public async void FillGame(int count)
        {
            if (Game.GameStarted())
            {
                StartFloatFakePlayers();
                return;
            }
           
            for (int i = 0; i < count; i++)
            {
                Random rnd = new Random();
                int sleep = rnd.Next(1, 3);
                Thread.Sleep(sleep * 1000);

                string name = FakeNames.ElementAtOrDefault(i);
                if (name != null)
                {
                    
                    if (!Game.GameStarted())
                    {
                        ApplicationUser user = new ApplicationUser();
                        user.UserName = name;
                        user.Email = "000111000";
                        await Game.AddPlayer(user);
                       
                           
                           
                       
                        
                    }
                    else break;
                        
                }
                else
                {
                    break;
                }

            }
            StartFloatFakePlayers();

        }

        
    }
}
