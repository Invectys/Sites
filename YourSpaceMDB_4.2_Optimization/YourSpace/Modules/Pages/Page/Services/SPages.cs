using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Data;
using YourSpace.Services;

namespace YourSpace.Modules.Pages.Page.Services
{
    public class SPages : ISPages
    {
        ApplicationDbContext _dbContext;
        UserManager<MIdentityUser> _userManager;
        ISFilesPathBuilder _sFilesPathBuilder;
        ISPagesUrl _sPagesUrl;
        public SPages(ApplicationDbContext dbContext,UserManager<MIdentityUser> userManager,ISFilesPathBuilder sFilesPathBuilder,
            ISPagesUrl sPagesUrl)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _sFilesPathBuilder = sFilesPathBuilder;
            _sPagesUrl = sPagesUrl;
        }

        public async Task<List<MPageInfo>> GetUserPagesById(string userId)
        {
            MIdentityUser user = await _userManager.FindByIdAsync(userId);
            return GetUserPages(user);
        }
        public async Task<List<MPageInfo>> GetUserPages(ClaimsPrincipal userClaims)
        {
            MIdentityUser user = await _userManager.GetUserAsync(userClaims);
            return GetUserPages(user);
        }
        public async Task<List<MPageInfo>> GetUserPages(string UserName)
        {
            MIdentityUser user = await _userManager.FindByNameAsync(UserName);
            return GetUserPages(user);
        }
        public List<MPageInfo> GetUserPages(MIdentityUser user)
        {
            return _dbContext.PagesInfo.Where(o => o.UserProfileId == user.Id).ToList();
        }

        public List<MPageInfo> GetAllPages()
        {
            return _dbContext.PagesInfo.ToList();
        }

        public MPageInfo GetPage(string id)
        {
            return _dbContext.PagesInfo.Find(id);
        }

        public List<MPageInfo> FindPages(string containName)
        {
            var list = new List<MPageInfo>();
            var urls = _sPagesUrl.GetAllUrls();
            var containedList = urls.Where(n => n.Url.Contains(containName));
            foreach(var url in containedList)
            {
                var page = GetPage(url.PageId);
                list.Add(page);
            }
            return list;
        }
       
    }
}
