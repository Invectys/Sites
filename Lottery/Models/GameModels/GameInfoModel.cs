using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class GameInfoModel
    {
        public string GameID { get; set; }
        public bool GameStarted { get; set; }
        public int Time { get; set; }
        public int TimeRemaining { get; set; }//dont set
        public float Rate { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public bool NeedMailConfirmed { get; set; }
    }
}
