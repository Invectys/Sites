using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class ArticleInfoModel : ArticleModel
    {
        public int Id { get; set; }
        public int PostWeekDelay { get; set; }
        public string OfferedDate { get; set; }
        public int PostWeek { get; set; }
    }
}
