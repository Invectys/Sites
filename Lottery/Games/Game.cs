using Lottery.Games;
using Lottery.Interfaces;
using Lottery.Models;
using Lottery.Other;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class Game : IGame
    {
        Timer timer = null;
        DateTime TimerStarted;

        public bool Onupdated = false;
        public string GameID = "";
        public int MaxPlayers = 5;
        public int MinPlayers = 1;
        public int GameTime = 10; //seconds
        public int DeltaTimeToJoin = 3; //seconds (DeltaTimeToJoin > GameTime)
        public float Rate = 10;
        public float Cash = 0;
        bool NeedMailConfirmed = false;


        public BotControl BotControl;
        public List<ApplicationUser> Players = new List<ApplicationUser>();
        

        UserManager<ApplicationUser> _userManager;

        private readonly ILogger<IGame> _logger;
        public readonly IHubSender _hubSender;
        FakeControl _fakeControl;
        public  int GameFakeLevel;
        public int MaxBotsCount;
        //private readonly LotteryOptions lotteryOptions;

        public Game(ILogger<IGame> Logger,IHubSender hubSender, UserManager<ApplicationUser> userManager,
            GameCreateModel info,LotteryOptions lotteryOptions,FakeControl fakeControl)
        {
            setGameCreateInfo(info);

            _userManager = userManager;
            _hubSender = hubSender;
            _logger = Logger;
            _fakeControl = fakeControl;
            _fakeControl.AddBotControl(this);


           
            
            

            
        }

        
        public Task StartGame()
        {
            _hubSender.StartGameServerEvent(GameID);
            TimerCallback tm = new TimerCallback(this.EndGame);
            timer = new Timer(tm, null, GameTime * 1000, -1);
            TimerStarted = DateTime.Now;
            return Task.FromResult(0);
        }

        public void EndGame(object o)
        {
            ApplicationUser winer = ChooseWiner();

            if(!winer.Email.Equals("000111000"))
            {
                winer.Money += Cash;


                _userManager.UpdateAsync(winer);

                Cash = 0;
            }
           
           
           _hubSender.EndGameServerEvent(winer,GameID);

            Players.Clear();
           
            timer = null;

            BotControl.onGameEnd();
        }

        public ApplicationUser ChooseWiner()
        {
            Random rand = new Random();
            int ind;
            ind = rand.Next(0, Players.Count - 1);
            int trying = GameFakeLevel;

            if (GameFakeLevel != 0)
            {
                if(GameFakeLevel < 0)
                {
                    trying = trying * -1;
                    while (Players.ElementAtOrDefault(ind).Email.Equals("000111000") && (trying > 0))
                    {
                        rand = new Random(ind + trying*10 + (int)DateTime.Now.Ticks);
                        ind = rand.Next(Players.Count);
                        trying--;
                    }  
                }
                if (GameFakeLevel > 0)
                {
                    while ( !Players.ElementAtOrDefault(ind).Email.Equals("000111000") && (trying > 0))
                    {
                        rand = new Random(ind*10 + trying + (int)DateTime.Now.Ticks);
                        ind = rand.Next(Players.Count);
                        trying--;
                    }
                }


            }
           
             
            return Players.ElementAtOrDefault(ind);
        }

        public async Task<GameJoinExceptions> JoinGame(HttpContext context)
        {
            
            ApplicationUser user = await _userManager.GetUserAsync(context.User);

            GameJoinExceptions ex = PlayerCanJoin(user);
            if (ex == GameJoinExceptions.NoException)
            {
                user.Money -= Rate;
                await _userManager.UpdateAsync(user);
                Cash += Rate;
                await AddPlayer(user);

            }
            return ex;
        }
        
        public async Task<bool> _StartGame()
        {
            if ((Players.Count == MinPlayers))
            {
                await StartGame();
                return true;
            }
            return false;
        }

        public bool ContainPlayer(ApplicationUser user)
        {
            
            foreach (ApplicationUser p in Players)
            {
                if (p.UserName == user.UserName)
                {
                    return true;
                   
                }
            }
            return false;
        }

        public async Task<bool> AddPlayer(ApplicationUser user)
        {
            
            if(user.Email.Equals("000111000"))
            {
                //for bots 
                if (Onupdated) return false;
                foreach (var p in Players)
                {
                    if (p.UserName.Equals(user.UserName)) return false;
                }
                _hubSender.PlayerJoined(user.UserName, GameID);
            }
           
            Players.Add(user);
            await _StartGame();

            return true;

        }



        public List<string> getPlayers()
        {
            List<string> List = new List<String>();
            foreach (var u in Players)
            {
                List.Add(u.UserName);
            }
            return List;
        }

        public GameInfoModel getGameInfo()
        {
            GameInfoModel info = new GameInfoModel();
            info.Time = GameTime; //seconds
            info.Rate = Rate;
            info.TimeRemaining = getTimeRemaining();
            info.GameStarted = timer != null;
            info.MinPlayers = MinPlayers;
            info.NeedMailConfirmed = NeedMailConfirmed;
            info.GameID = GameID;
            info.MaxPlayers = MaxPlayers;
            return info;
        }
        public GameCreateModel getGameCreateInfo()
        {
            GameCreateModel info = new GameCreateModel();
            info.Time = GameTime; //seconds
            info.Rate = Rate;
            
            info.MinPlayers = MinPlayers;
            info.NeedMailConfirmed = NeedMailConfirmed;
            info.GameID = GameID;
            info.MaxPlayers = MaxPlayers;
            info.DeltaTimeToJoin = DeltaTimeToJoin;
            return info;
        }
        public void setGameCreateInfo(GameCreateModel info)
        {
           
            MaxPlayers = info.MaxPlayers;
            MinPlayers = info.MinPlayers;
            GameTime = info.Time;
            Rate = info.Rate;
            GameID = info.GameID;
            NeedMailConfirmed = info.NeedMailConfirmed;
            DeltaTimeToJoin = info.DeltaTimeToJoin;
            GameFakeLevel = info.GameFakeLevel;
            MaxBotsCount = info.MaxBotsCount;
            
        }

        public  void updateGameInfo(object info)
        {
            Onupdated = true;
            if (GameStarted())
            {
                TimerCallback tm = new TimerCallback(updateGameInfo);
                Timer timer1 = new Timer(tm, info, (GameTime - getTimeRemaining() + 1) * 1000 , -1);
                return;
            }
            GameCreateModel model = (GameCreateModel)info;
            setGameCreateInfo(model);
            _hubSender.Gameupdated(GameID,Gameupdate.GameInformationMustChanged);
            Onupdated = false;
        }
        public GameInfoMinModel getGameInfoMin()
        {
            GameInfoMinModel info = new GameInfoMinModel();
            info.Rate = Rate;
            info.MaxPlayers = MaxPlayers;
            info.Cash = Cash;
            info.Time = GameTime;
            return info;
        }
        
        public int getTimeRemaining()
        {
            if (GameStarted())
            {
                return (DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60 * 60 + DateTime.Now.Day * 24 * 60 * 60) -
                  (TimerStarted.Second + TimerStarted.Minute * 60 + TimerStarted.Hour * 60 * 60 + TimerStarted.Day * 24 * 60 * 60);
            }
            else return 0;
           
        }
        public bool GameStarted()
        {
            return timer != null;
        }

        public GameJoinExceptions PlayerCanJoin(ApplicationUser user)
        {
            

            if (user == null) return GameJoinExceptions.NoUser;
            if (NeedMailConfirmed) if (!user.EmailConfirmed) return GameJoinExceptions.NoMailConfirmed;
            if (ContainPlayer(user)) return GameJoinExceptions.UserAlreadyInGame;
            if (Players.Count == MaxPlayers) return GameJoinExceptions.UsersLimit;
            if (user.Money < Rate) return GameJoinExceptions.NoMoney;
            int t = getTimeRemaining();
            int dt = (GameTime - DeltaTimeToJoin);
            if (GameStarted()) if (t > dt) return GameJoinExceptions.GameStarted;
            if (Onupdated) return GameJoinExceptions.GameMustBeupdated;
            return GameJoinExceptions.NoException;
        }

        public void setBotControl(BotControl botControl)
        {
            BotControl = botControl;
        }
        public int GetGameFakeLevel() => GameFakeLevel;
        public int GetMaxBotsCount() => MaxBotsCount;
        public int GetMaxPlayers() => MaxPlayers;
        public string GetID() => GameID;
        
    }

    public enum GameJoinExceptions 
    {
        NoException,
        NoMailConfirmed,
        NoUser,
        UserAlreadyInGame,
        UsersLimit,
        NoMoney,
        GameStarted,
        GameMustBeupdated


    }
    public enum Gameupdate
    {
        GameInformationMustChanged,
        GameDeleted
    }




}

