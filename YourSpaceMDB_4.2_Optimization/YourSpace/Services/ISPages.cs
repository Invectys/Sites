


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Services
{
    public interface ISPages
    {
        public Task<List<MPageInfo>> GetUserPagesById(string userId);
        public Task<List<MPageInfo>> GetUserPages(ClaimsPrincipal userClaims);
        public Task<List<MPageInfo>> GetUserPages(string UserName);
        public List<MPageInfo> GetUserPages(MIdentityUser user);
        public List<MPageInfo> GetAllPages();
        public List<MPageInfo> FindPages(string containName);


    }
}
