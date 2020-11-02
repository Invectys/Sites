using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryMVC.Models
{
    public class TwiloConfiguration
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string VerifyServiceSid { get; set; }
        public bool TwiloEnabled { get; set; }
    }
}
