using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryMVC.Models
{
    public class EmailConfiguration
    {
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public string SmptHost { get; set; }
        public int SmptPort { get; set; }
        public string AuthMail { get; set; }
        public string Password { get; set; }
        public bool EmailEnabled { get; set; }
    }
}
