using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryMVC.Models
{
    

    
    public class Note
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Note()
        {
            Date = DateTime.Now;
        }
       
        public string Json { get; set; }
        public DateTime Date { get; protected set; }
        public int Type { get; set; }
    }
}
