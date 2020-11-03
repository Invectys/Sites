using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Data;
using YourSpace.Modules.ConfigurationModels;
using YourSpace.Modules.EmailSender;
using YourSpace.Modules.Localization;
using YourSpace.Modules.Moderation.Models;
using YourSpace.Services;

namespace YourSpace.Modules.Moderation
{
    public class SUsersModeration : ISUsersModeration
    {
        UserManager<MIdentityUser> _userManager;
        ApplicationDbContext _dbContext;
        ISRoles _sRoles;
        ISUserProfile _sUserProfile;
        IEmailSender _emailSender;
        LEmailMessages _lEmailMessages;
        MDefaultSettings _options;
        SEmailHtmlMessagesReader _sEmailMessages;

        public SUsersModeration(UserManager<MIdentityUser> userManager,ApplicationDbContext dbContext,
            ISRoles sRoles,ISUserProfile sUserProfile, IEmailSender emailSender,LEmailMessages lEmailMessages,
            IOptions<MDefaultSettings> options,SEmailHtmlMessagesReader sEmailMessages)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _sRoles = sRoles;
            _sUserProfile = sUserProfile;
            _emailSender = emailSender;
            _lEmailMessages = lEmailMessages;
            _options = options.Value;
            _sEmailMessages = sEmailMessages;
        }
        

        public async Task DeleteUser(string userId)
        {
            MIdentityUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
        public async Task<MEditUser> GetEditUser(string userId)
        {
            MIdentityUser user = await _userManager.FindByIdAsync(userId);
            if(user != null)
            {
                return user.GetEditUser();
            }
            return null;
        }
        public async Task EditUser(string userId,MEditUser editUser)
        {
            MIdentityUser user = await _userManager.FindByIdAsync(userId);
            if(user != null)
            {
                user.ApplyEditUser(editUser);
                await _userManager.UpdateAsync(user);
            }
        }

        public async Task<(IdentityResult,MIdentityUser)> CreateUser(MCreateUser createUser)
        {
            MIdentityUser newUser = new MIdentityUser();
            newUser.ApplyCreateUser(createUser);

            var result = await _userManager.CreateAsync(newUser,createUser.Password);
            if(result.Succeeded)
            {
                //var user = await _userManager.FindByNameAsync(newUser.UserName);
                await _sRoles.SetRole(newUser, createUser.Role);
                await _sUserProfile.InitUserProfile(newUser);
                
                return (result, newUser);
            }
            return (result, null);

        }

        public async Task SendEmailVerificationMessage(MIdentityUser user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = $"{_options.Domain}Identity/Account/ConfirmEmail?userId={user.Id}&code={code}";
            var message = _sEmailMessages.GetConfirmEmailMessage(callbackUrl);
            await _emailSender.SendEmailAsync(user.Email, _lEmailMessages["EmailConfirmSubject"], message);
        }
        
    }
}
