using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;

namespace YourSpace.Services
{
    public class STest
    {
        private UserManager<MIdentityUser> _userManager;
        public MIdentityUser User { get; set; }
        public STest(UserManager<MIdentityUser> userManager)
        {
            _userManager = userManager;
           

            
        }

        public async Task LoadUser(ClaimsPrincipal user)
        {
            User = await _userManager.GetUserAsync(user);
        }
    }
}
