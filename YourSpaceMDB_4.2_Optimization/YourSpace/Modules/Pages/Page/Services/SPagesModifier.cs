using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Data;
using YourSpace.Modules.Configuration.ConfigurationModels;
using YourSpace.Modules.ConfigurationModels;
using YourSpace.Modules.Localization;
using YourSpace.Modules.Pages.Blocks;
using YourSpace.Modules.Pages.Page.Models;
using YourSpace.Modules.ThingCounter;
using YourSpace.Services;

namespace YourSpace.Modules.Pages.Page
{
    public class SPagesModifier : ISPagesModifier
    {
        private readonly ISPageStream _sPageStream;
        private readonly UserManager<MIdentityUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly ISFilesPathBuilder _sFilesPathBuilder;
        private readonly ISPagesUrl _sPagesUrl;
        private readonly ISPagesCasher _sPagesCacher;
        private readonly ISThingCounter _sMarks;
        private readonly ISRoles _sRoles;
        private readonly LPage _lPage;
        MUrlDenyWords denyWords = new MUrlDenyWords()
        {
            Words = { "all", "admin","identity","moderator","complete" }
        };

        private MPageSettings _defaultPageSettings;


        public SPagesModifier(ISPageStream sPageStream, 
            UserManager<MIdentityUser> userManager,ApplicationDbContext dbContext, ISFilesPathBuilder sFilesPathBuilder,
            ISPagesUrl sPagesUrl,ISPagesCasher sPagesCacher,ISThingCounter sMarks,IOptions<MPageSettings> pageSettings,
            ISRoles sRoles,LPage lPage
           )
        {
            _sPageStream = sPageStream;
            _userManager = userManager;
            _dbContext = dbContext;
            _sFilesPathBuilder = sFilesPathBuilder;
            _sPagesUrl = sPagesUrl;
            _sPagesCacher = sPagesCacher;
            _sMarks = sMarks;
            _sRoles = sRoles;
            _lPage = lPage;

            _defaultPageSettings = pageSettings.Value;
        }

        public async Task<CreatePageResult> CreateNewPage(MCreatePage model, ClaimsPrincipal principal)
        {
            var result = new CreatePageResult();

            //validate url
            if(denyWords.Words.Contains(model.Url.ToLower()))
            {
                result.Succeeded = false;
                result.Errors.Add("Url is prohibited");
                return result;
            }


            MPage page = new MPage();
            bool created = _sPagesUrl.TryCreatePageUrl(model.Url,out string id);
            if(!created)
            {
                result.Succeeded = false;
                result.Errors.Add("Url is occuped");
                return result;
            }
            page.Id = id;

            if (model.DisplayBlock.ImageBackground == "")
            {
                model.DisplayBlock.ImageBackground = _lPage["PageImage"];
            }

            MPageCardBlock displayBlock = model.DisplayBlock;
            displayBlock.Name = page.Id;
            page.DisplayCard = displayBlock;

            return await CreateNewPage(page, principal);
        }

        public async Task<CreatePageResult> CreateNewPage(MPage page, ClaimsPrincipal principal)
        {
            
            var result = new CreatePageResult();
            MIdentityUser user = await _userManager.GetUserAsync(principal);
            
            string pageId = page.Id;
            MPageInfo info = _dbContext.PagesInfo.Find(pageId);
            if(info == null)
            {

                var newPageInfo = new MPageInfo() { Id = pageId, UserProfileId = user.Id };
                var role = await _sRoles.GetRole(user);
                newPageInfo.SetInfo(role);
                

                _dbContext.PagesInfo.Add(newPageInfo);
                await _dbContext.SaveChangesAsync();
                await _sPageStream.WritePage(page);
                result.Page = page;
                result.Succeeded = true;
                
            }
            else
            {
                result.Succeeded = false;
                result.Errors.Add("Page already exist");
            }

           
            return result;
        }
        public async Task DeletePage(string pageId)
        {
            MPageInfo info = _dbContext.PagesInfo.Find(pageId);
            if (info != null)
            {
                //Delete marks
                _sMarks.RemoveAllWherePage(pageId, MCounterType.Like());
                _sMarks.RemoveAllWherePage(pageId, MCounterType.Subscribe());

                _sPagesCacher.ClearPageCache(pageId);

                //Free Url
                await _sPagesUrl.DeleteUrl(info.Id);

                //delete info
                _dbContext.PagesInfo.Remove(info);
                await _dbContext.SaveChangesAsync();

                //Delete Page
                var page = _dbContext.PagesData.First(p => p.Id == pageId);
                _dbContext.PagesData.Remove(page);
                await _dbContext.SaveChangesAsync();


            }


        }
        public async Task<bool> UserOwnPage(ClaimsPrincipal userClaims, string pageName)
        {
            MIdentityUser user = await _userManager.GetUserAsync(userClaims);
            MPageInfo pageInfo = _dbContext.PagesInfo.Find(pageName);
            MUserProfile profile = _dbContext.UserProfiles.Find(pageInfo.UserProfileId);
            bool isOwner = profile.UserId == user.Id;
            return isOwner;
        }


        public MPageInfo GetPageInfo(string pageId)
        {
            MPageInfo pageInfo = _dbContext.PagesInfo.Find(pageId);
            return pageInfo;
        }
        public async void SetPageInfo(MPageInfo newInfo)
        {
            _dbContext.PagesInfo.Update(newInfo);
            await _dbContext.SaveChangesAsync();
        }


    }

    public class CreatePageResult 
    {
        public bool Succeeded { get; set; }
        public MPage Page { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }


}
