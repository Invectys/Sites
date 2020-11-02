using Microsoft.AspNetCore.Identity;

namespace LotteryMVC.Models
{
    public class User : IdentityUser
    {
        public string Year { get;  set; }
        public int Money { get; set; }
        
        public bool Banned { get; set; }
    }
}