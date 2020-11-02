using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models.Social
{
    public class LikeAction
    {
        public LikeAction(string From,string To)
        {
            this.From = From;
            this.To = To;
        }

        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }

    }
}
