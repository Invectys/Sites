using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;

namespace YourSpace.Modules.Authorization.Requirements
{
    public class HandlerRequirementMinAge : AuthorizationHandler<RequirementMinimumAge>
    {
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            RequirementMinimumAge requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
