using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryMVC.Models
{
    public class NotifyGameResultModel : NotifyModel
    {
        public NotifyGameResultModel()
        {
            Type = (int)NotifyType.GameResult;
        }
       public int Money { get; set; }
       public int GameIdentifier { get; set; }
       public bool Win { get; set; }
    }
}
