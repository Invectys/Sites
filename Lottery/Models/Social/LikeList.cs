using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models.Social
{
    public class LikeList
    {
        public int? Id { get; set; }
        public string Object { get; set; }
        public int Likes { get; set; }

        public LikeList(string Object,int likes = 0)
        {
            this.Object = Object;
            this.Likes = likes;
        }
        
    }
}
