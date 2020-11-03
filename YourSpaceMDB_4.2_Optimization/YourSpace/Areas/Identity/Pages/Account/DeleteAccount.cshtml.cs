using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using YourSpace.Areas.Identity;
using YourSpace.Modules.ConfigurationModels;
using YourSpace.Services;

namespace YourSpace.Areas.Identity.Pages.Account
{

    public class DeleteAccount
    {

    }

    [AllowAnonymous]
    public class DeleteAccountModel : PageModel
    {
        private readonly SignInManager<MIdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly ISUserProfile _sUserProfile;
        MRootAccountSettings owner;

        public DeleteAccountModel(SignInManager<MIdentityUser> signInManager, ILogger<LogoutModel> logger,
            ISUserProfile sUserProfile,IOptions<MRootAccountSettings> options)
        {
            _signInManager = signInManager;
            _logger = logger;
            _sUserProfile = sUserProfile;
            owner = options.Value;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(HttpContext.User.Identity.Name != owner.Email)
            {
                await _signInManager.SignOutAsync();
                await _sUserProfile.DeleteAccount(HttpContext.User);
                return Redirect("Complete");
            }
            return Page();
        }
    }
}
