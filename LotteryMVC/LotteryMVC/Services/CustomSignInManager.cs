using LotteryMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryMVC.Services
{
    public class CustomSignInManager : SignInManager<User>
    {
        private readonly IdentityOptions _options;
        public CustomSignInManager(UserManager<User> userManager, IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<User> claimsFactory, IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<User>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<User> confirmation)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
            _options = optionsAccessor.Value;
        }
        public override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool rememberMe, bool shouldLockout)
        {
            var user = UserManager.FindByNameAsync(userName).Result;
            if (user != null)
            {
                if (user.Banned)
                {
                    return Task.FromResult<SignInResult>(MySignInResult.Banned);
                }
                if(!user.EmailConfirmed && _options.SignIn.RequireConfirmedEmail)
                {
                    return Task.FromResult<SignInResult>(MySignInResult.EmailNotConfirme);
                }

            }


            return base.PasswordSignInAsync(userName, password, rememberMe, shouldLockout);
        }
    }

    public class MySignInResult : SignInResult
    {
        public MySignInResult()
        {
            isBanned = false;
            EmailNotConfirmed = false;
        }
        public bool isBanned { get; protected set; }
        public static MySignInResult Banned { get { var n = new MySignInResult();n.isBanned = true; return n; } }

        public bool EmailNotConfirmed { get; protected set; }
        public static MySignInResult EmailNotConfirme { get { var n = new MySignInResult(); n.EmailNotConfirmed = true; return n; } }
    }

    


}
