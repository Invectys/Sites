using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class MainOptions
    {
        public MainOptions()
        {
            OneRubbleInCatMoney = 100;
            OneDollarInCatMoney = 1000;
            List<GameCreateModel> Games = new List<GameCreateModel>();
        }

       
        public float OneRubbleInCatMoney { get; set; }
        public float OneDollarInCatMoney { get; set; }

        public List<GameCreateModel> Games { get; set; }

        public string MailTheme { get; set; }
        public string FromMailBox { get; set; }
        public int smpt_port { get; set; }
        public string smpt_host { get; set; }
        public string smpt_login { get; set; }
        public string smpt_password { get; set; }

        
    }
}
