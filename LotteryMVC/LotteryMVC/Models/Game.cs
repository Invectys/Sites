using LotteryMVC.Hubs;
using LotteryMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace LotteryMVC.Models
{
    public class Game
    {
        UserManager<User> _userManager;
        IHubContext<GameHub> _gameHub;
        IHubContext<NotificationHub> _notificationHub;
        HistoryService _historyService;
        public Game(UserManager<User> userManager,IHubContext<GameHub> gameHub, IHubContext<NotificationHub> notificationHub,int Identifier,HistoryService historyService,GameViewModel model = null)
        {
            _userManager = userManager;
            _gameHub = gameHub;
            _notificationHub = notificationHub;
            _historyService = historyService;

            Information = new GameFullModel();

            if (model == null)
            {
                Information.NeedPlayers = 2;
                Information.Rate = 10;
                Information.NeedPhoneConfirmed = false;
            }
            else
            {
                Information.NeedPlayers = model.NeedPlayers;
                Information.Rate = model.Rate;
                Information.NeedPhoneConfirmed = model.NeedPhoneConfirmed;
            }


            Information.Identifier = Identifier;
            Information.TimeGameProcess = 3000;
            Information.InProcess = false;
        }
        
        private GameFullModel Information;
        private int DeltaTimeConnection = 3000;
        public async void Start()
        {
            Information.InProcess = true;
            await _gameHub.Clients.Group(Information.Identifier.ToString()).SendAsync("GameStart");
            TimerCallback tm = new TimerCallback(Start_Implementation);
            Timer timer = new Timer(tm, null, DeltaTimeConnection, Timeout.Infinite);
        }
        private void Start_Implementation(object obj)
        {
            TimerCallback tm = new TimerCallback(End);
            Information.TimerStartDate = DateTime.Now;
            Information.TimerToEnd = new Timer(tm, null, Information.TimeGameProcess, Timeout.Infinite);
        }
        public async void End(object obj)
        {
            
            Information.TimerToEnd.Dispose();

            int winnerInd = CalckWinner();
            CalckGameResult(winnerInd);
            
            User playerWinned = Information.Players[winnerInd];

            await  _gameHub.Clients.Group(Information.Identifier.ToString()).SendAsync("GameEnd", playerWinned.UserName);
            GameResultNotify(winnerInd);

            ResetGame();
        }

        private void GameResultNotify(int winner)
        {
            NotifyGameResultModel notify = new NotifyGameResultModel();
            notify.GameIdentifier = Information.Identifier;
            notify.Text = "You lose in Game !";
            notify.Money = 0;
            notify.Win = false;

            

            for (int i=0; i < Information.PlayersNum;i++)
            {
                if (i == winner) continue;
                string id = Information.Players[i].Id;
                
                
                _notificationHub.Clients.User(id).SendAsync("Notify", notify);
                _historyService.AddNote(notify, id);
            }

            notify.Money = FullCash();
            notify.Win = true;
            notify.Text = "You won Game !";
            string wid = Information.Players[winner].Id;
            _notificationHub.Clients.User(wid).SendAsync("Notify", notify);

            _historyService.AddNote(notify, wid);
        }

        private void ResetGame()
        {
            Information.RemoveAllPlayers();
            TimerCallback tm = new TimerCallback(ResetGame_Implementation);
            Timer timer = new Timer(tm, null, DeltaTimeConnection, Timeout.Infinite);
        }
        private void ResetGame_Implementation(object o)
        {
            
            Information.InProcess = false;
        }
        public async Task<JoinRules> Join(ClaimsPrincipal cl)
        {
            User user = await _userManager.GetUserAsync(cl);
            if (user == null) return JoinRules.NoAuth;

            JoinRules state = CanUserJoin(user);
            switch (state)
            {
                case JoinRules.Ok:
                    Information.AddPlayer(user);
                    user.Money -= Information.Rate;
                    await _userManager.UpdateAsync(user);
                    await _gameHub.Clients.Group(Information.Identifier.ToString()).SendAsync("PlayerJoin", user.UserName);

                    switch (CanStartGame())
                    {
                        case StartGameRules.Ok:
                            Start();
                            break;
                    }

                    break;
            }
           

            return state;
        }

        
        public async Task<ExitRules> Exit(ClaimsPrincipal cl)
        {
            User user = await _userManager.GetUserAsync(cl);
            if (user == null) return ExitRules.NoAuth;

            ExitRules state = CanPlayerExit(user);
            switch (state)
            {
                case ExitRules.Ok:
                    Information.RemovePlayer(user);
                    user.Money += Information.Rate;
                    await _userManager.UpdateAsync(user);
                    await _gameHub.Clients.Group(Information.Identifier.ToString()).SendAsync("PlayerExit", user.UserName);
                    break;
            }
            
            
            return state;
        }
        
       
        public int CalckWinner()
        {
            int min = 0;
            int max = Information.PlayersNum - 1;
            int seed = Math.Abs(DateTime.Now.Second + DateTime.Now.Day - DateTime.Now.Millisecond); 
            Random rnd = new Random(seed);
            int ind = rnd.Next(min, max);
            return ind;
        }

        public async void CalckGameResult(int winner)
        {
            User us = Information.Players[winner];
            User playerWinned = _userManager.FindByNameAsync(us.UserName).Result;
            int Money = FullCash();
            playerWinned.Money += Money;
            await _userManager.UpdateAsync(playerWinned);

            
        }
        
        

        public StartGameRules CanStartGame()
        {
            if (Information.Players.Count < Information.NeedPlayers) return StartGameRules.NeedMorePlayers;
            return StartGameRules.Ok;
        }
        public JoinRules CanUserJoin(User user)
        {
            if (Information.PlayersNum == Information.NeedPlayers) return JoinRules.TooMuchPlayers;
            if (Information.InProcess) return JoinRules.GameStarted;
            if (user.Money < Information.Rate) return JoinRules.NoMoney;
            if (UserInGame(user)) return JoinRules.UserAlreadyInGame;
            if (!user.PhoneNumberConfirmed && Information.NeedPhoneConfirmed) return JoinRules.NeedPhoneConfirmed;

            return JoinRules.Ok;
        }
        public ExitRules CanPlayerExit(User player)
        {
            if (Information.InProcess) return ExitRules.GameStarted;
            if (!UserInGame(player)) return ExitRules.UserNotInGame;
            return ExitRules.Ok;
        }
        public bool UserInGame(User user)
        {
            bool b = (Information.Players.Exists(o=>o.Email == user.Email));
            return b;
        }
        public int FullCash() => Information.Rate * Information.PlayersNum;
        public bool isStarted() => Information.InProcess;
        public GameViewModel getViewModel() => Information.getViewModel();
        public GameConfigureModel getConfigureModel() => Information.getConfigureModel();
        


        
    }


    public enum JoinRules
    {
        Ok,
        TooMuchPlayers,
        GameStarted,
        NoMoney,
        UserAlreadyInGame,
        NeedPhoneConfirmed,
        NoAuth
        
    }
    public enum ExitRules
    {
        Ok,
        GameStarted,
        UserNotInGame,
        NoAuth
    }
    public enum StartGameRules
    {
        Ok,
        NeedMorePlayers
    }
}
