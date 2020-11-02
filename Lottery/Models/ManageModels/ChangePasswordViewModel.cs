using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string NewPassword { get; set; }
    }
}
