using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models.PartialViewModels
{
    public class SlideBarModel
    {
        public string PageName { get; set; }
        public string Owner { get; set; }
        public int Likes { get; set; }
        public bool PageLiked { get; set; }
    }
}
