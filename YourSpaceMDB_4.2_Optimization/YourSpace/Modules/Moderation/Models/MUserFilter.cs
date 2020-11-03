using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.Moderation.Models
{
    public class MUserFilter
    {
        public string FirstName { get; set; } = "";
        public string  Email { get; set; } = "";
    }

    public enum SortUsers
    {
        Email
    }
}
