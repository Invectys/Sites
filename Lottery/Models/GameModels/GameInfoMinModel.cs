using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class GameInfoMinModel
    {
        
        public float Rate { get; set; }
        public int MaxPlayers { get; set; }
        public float Cash { get; set; }
        public int Time { get; set; }
    }
}
