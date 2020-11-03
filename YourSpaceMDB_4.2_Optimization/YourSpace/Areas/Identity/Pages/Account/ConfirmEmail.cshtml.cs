using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using YourSpace.Areas.Identity;
using YourSpace.Modules.URL;

namespace YourSpace.Areas.Identity.Pages.Account
{

    public class ConfirmEmailPage { }

    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<MIdentityUser> _userManager;
        SURL _sURL;

        public ConfirmEmailModel(UserManager<MIdentityUser> userManager,SURL sURL)
        {
            _userManager = userManager;
            _sURL = sURL;
        }

        [TempData]
        public string StatusMessage { get; set; }
        public bool Succeeded { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return Redirect(_sURL.NotFound);
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {

                return Redirect(_sURL.NotFound);
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            Succeeded = result.Succeeded;
            return Page();
        }
    }
}
