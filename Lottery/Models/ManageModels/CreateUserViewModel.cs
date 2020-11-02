using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class CreateUserViewModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Money { get; set; }
    }
}
