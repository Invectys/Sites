using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YourSpace.Areas.Identity.Pages.Account
{

    public class Complete
    {

    }

    [AllowAnonymous]
    public class CompleteModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}
