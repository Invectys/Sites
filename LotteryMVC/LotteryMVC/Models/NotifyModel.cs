using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryMVC.Models
{
    public class NotifyModel
    {
        public int Type { get; protected set; }
        public string Text { get; set; }

        public NotifyModel()
        {
            Type = (int)NotifyType.Default;
        }
        protected enum NotifyType
        {
            GameResult,
            Default
            
        }
       
        
    }

    
    
}
