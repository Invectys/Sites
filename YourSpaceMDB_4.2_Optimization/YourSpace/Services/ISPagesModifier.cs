using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Services
{
    public interface ISPagesModifier
    {
        public Task<CreatePageResult> CreateNewPage(MCreatePage model, ClaimsPrincipal principal);
        public  Task<CreatePageResult> CreateNewPage(MPage page, ClaimsPrincipal principal);
        public Task DeletePage(string pageId);
        public Task<bool> UserOwnPage(ClaimsPrincipal user, string pageName);
        public MPageInfo GetPageInfo(string pageName);
        public void SetPageInfo(MPageInfo newInfo);
    }
}
