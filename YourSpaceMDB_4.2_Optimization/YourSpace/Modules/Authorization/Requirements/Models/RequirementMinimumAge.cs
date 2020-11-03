using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.Authorization.Requirements
{
    public class RequirementMinimumAge : IAuthorizationRequirement
    {
        public int MinAge { get; set; }

        public RequirementMinimumAge(int minAge)
        {
            MinAge = minAge;
        }
    }
}
