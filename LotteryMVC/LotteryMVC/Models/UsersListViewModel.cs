using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryMVC.Models
{
    public class UsersListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public string Name { get; set; }
    }
}
