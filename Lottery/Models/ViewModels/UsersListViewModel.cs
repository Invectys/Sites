using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class UsersListViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
       
        public string Name { get; set; }
    }
}
