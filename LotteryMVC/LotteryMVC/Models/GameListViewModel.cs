using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryMVC.Models
{
    public class GameListViewModel
    {
        public List<LotteryMVC.Models.GameViewModel> Games { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public int RateMin { get; set; }
        public int RateMax { get; set; }
    }
}
