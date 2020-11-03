using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Data;
using YourSpace.Modules.Pages.Page;
using YourSpace.Services;

namespace YourSpace.Pages
{
    public partial class PagesManagment : ComponentBase
    {


        public List<MPageInfo> OwnPages { get; set; }

        [Inject] protected ISPagesModifier SPagesModifier { get; set; }
        [Inject] protected ISPages SPages { get; set; }
        [CascadingParameter] protected Task<AuthenticationState> authenticationState { get; set; }
        protected ClaimsPrincipal userClaims { get; set; }


        protected override async Task OnInitializedAsync()
        {
            userClaims = (await authenticationState).User;
            OwnPages = await SPages.GetUserPages(userClaims);
        }
    }
}
