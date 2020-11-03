using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;

namespace YourSpace.Services
{
    public interface ISUserProfile
    {
        public Task<MIdentityUser> GetUser(ClaimsPrincipal claims);
        public Task<MIdentityUser> GetUser(string name);
        public Task<bool> CanCreatePage(string userId);
        public MUserProfile GetProfile(string userId);
        public Task SetUserProfileImage(ClaimsPrincipal claims, string Image);
        public Task<string> GetUserProfileImage(ClaimsPrincipal claims);
        public Task<bool> CanCreatePage(ClaimsPrincipal claims);
        public string GetUserProfileImage(MIdentityUser user);
        public Task<string> GetUserProfileImage(string userName);
        public Task<string> GetPersonalDataZip(ClaimsPrincipal claims);
        public void DeleteImages(ClaimsPrincipal claims);
        public Task DeletePages(ClaimsPrincipal claims);
        public Task DeleteAccount(ClaimsPrincipal claims);
        public Task<MUserProfile> InitUserProfile(MIdentityUser user);
        public Task<MUserProfile> InitUserProfile(string userId);
        public Task RemoveProfile(string userId);
        public Task RemoveProfile(MIdentityUser user);
        public Task UpdateProfile(MUserProfile profile);
    }
}
