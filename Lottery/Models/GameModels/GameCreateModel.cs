using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class GameCreateModel
    {
        public int Time { get; set; }
        public string GameID { get; set; }//dont set 
        public float Rate { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int DeltaTimeToJoin { get; set; }
        public bool NeedMailConfirmed { get; set; }
        public int GameFakeLevel { get; set; }
        public int MaxBotsCount { get; set; }
    }
}
