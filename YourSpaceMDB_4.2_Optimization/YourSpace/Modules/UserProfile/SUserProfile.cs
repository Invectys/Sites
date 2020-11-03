using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Data;
using YourSpace.Modules.FilesPathBuilder;
using YourSpace.Modules.Pages.Page;
using YourSpace.Services;

namespace YourSpace.Modules.UserProfile
{
    public class SUserProfile : ISUserProfile
    {
        UserManager<MIdentityUser> _userManager;
        ApplicationDbContext _dbContext;
        ISFilesPathBuilder _sPathBuilder;
        ISPages _sPages;
        ISPagesModifier _sPagesModifier;
        ISRoles _sRoles;

        public SUserProfile(UserManager<MIdentityUser> userManager, ApplicationDbContext dbContext,
            ISFilesPathBuilder sPathBuilder,ISPages sPages,ISPagesModifier sPagesModifier, ISRoles sRoles)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _sPathBuilder = sPathBuilder;
            _sPages = sPages;
            _sPagesModifier = sPagesModifier;
            _sRoles = sRoles;
        }
        public async Task<MIdentityUser> GetUser(string name)
        {
            MIdentityUser user = await _userManager.FindByNameAsync(name);
            return user;
        }
        public async Task<MIdentityUser> GetUser(ClaimsPrincipal claims)
        {
            MIdentityUser user = await _userManager.GetUserAsync(claims);
            return user;
        }
        
        public async Task RemoveProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await RemoveProfile(user);
        }
        public async Task RemoveProfile(MIdentityUser user)
        {
            var profile = await _dbContext.UserProfiles.FindAsync(user.Id);
            _dbContext.UserProfiles.Remove(profile);
        }
        public async Task<MUserProfile> InitUserProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return await InitUserProfile(user);
        }
        public async Task<MUserProfile> InitUserProfile(MIdentityUser user)
        {
            var role = await _sRoles.GetRole(user);

            MUserProfile profile = new MUserProfile();
            profile.UserId = user.Id;
            profile.ProfileImage = role.StartProfileImage;

            _dbContext.UserProfiles.Add(profile);
            await _dbContext.SaveChangesAsync();
            return profile;
        }
        public MUserProfile GetProfile(string userId)
        {
            return _dbContext.UserProfiles.Find(userId);
        }

        public async Task<bool> CanCreatePage(ClaimsPrincipal claims)
        {
            var user = await _userManager.GetUserAsync(claims);
            return await CanCreatePage(user.Id);
        }
        public async Task<bool> CanCreatePage(string userId)
        {
            var role = await _sRoles.GetRole(userId);
            int maxPages = role.MaxPagesAmount;
            var pages = await _sPages.GetUserPagesById(userId);
            return maxPages > pages.Count;
        }

        public async Task UpdateProfile(MUserProfile profile)
        {
            _dbContext.UserProfiles.Update(profile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SetUserProfileImage(ClaimsPrincipal claims, string Image)
        {
            MIdentityUser user = await GetUser(claims);
            MUserProfile profile = GetProfile(user.Id);

            profile.ProfileImage = Image;
            _dbContext.UserProfiles.Update(profile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> GetUserProfileImage(string userName)
        {
            MIdentityUser user = await _userManager.FindByNameAsync(userName);
            return GetUserProfileImage(user);
        }
        public async Task<string> GetUserProfileImage(ClaimsPrincipal claims)
        {
            MIdentityUser user = await GetUser(claims);
            return GetUserProfileImage(user);
        }
        public string GetUserProfileImage(MIdentityUser user)
        {
            
            MUserProfile profile = GetProfile(user.Id);
            if (profile.ProfileImage == null) return "https://image.freepik.com/free-photo/smiling-young-man-wearing-sunglasses-taking-selfie-showing-thumb-up-gesture_23-2148203116.jpg";
            return profile.ProfileImage;
        }
        public async Task<string> GetPersonalDataZip(ClaimsPrincipal claims)
        {
            MIdentityUser user = await GetUser(claims);
            using(var memoryStream = new MemoryStream())
            {
                using(var zip = new ZipArchive(memoryStream,ZipArchiveMode.Create,true))
                {
                    string imagesPath = _sPathBuilder.getFullRootUserDataPath(claims.Identity.Name,_sPathBuilder.ImagesFolderName);
                    string[] images = Directory.GetFiles(imagesPath);
                    foreach(var image in images)
                    {
                        zip.CreateEntryFromFile(image,"data/images/" + image.Split('\\').Last());
                    }

                    var entry = zip.CreateEntry("user.txt");
                    using(StreamWriter writer  = new StreamWriter(entry.Open()))
                    {
                        writer.WriteLine("First name = " + user.FirstName);
                        writer.WriteLine("Last name = " + user.LastName);
                        writer.WriteLine("Email = " + user.Email);
                    }
                }
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
        public void DeleteImages(ClaimsPrincipal claims)
        {
            string path = _sPathBuilder.getFullRootDataPath(claims.Identity.Name, _sPathBuilder.ImagesFolderName);
            string pathTo = _sPathBuilder.getDeletedDataPath(claims.Identity.Name + DateTime.Now.ToString("_dd_MM_yyyy"));
            string[] files = Directory.GetFiles(path);
            foreach(var file in files)
            {
                string pathTo2 = Path.Combine(pathTo, file.Split("\\").Last());
                File.Move(file, pathTo2);
            }
        }
        public async Task DeletePages(ClaimsPrincipal claims)
        {
            var pages = await _sPages.GetUserPages(claims);
            foreach (var page in pages)
            {
                await _sPagesModifier.DeletePage(page.Id);
            }
        }
        public async Task DeleteAccount(ClaimsPrincipal claims)
        {
            await DeletePages(claims);
            DeleteImages(claims);

            MIdentityUser user = await GetUser(claims);
            await _userManager.DeleteAsync(user);

        }

       
    }
}
