using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Modules.Moderation.Models;

namespace YourSpace.Services
{
    public interface ISUsersModeration
    {
        public Task<MEditUser> GetEditUser(string userId);
        public Task DeleteUser(string userId);
        public Task EditUser(string userId, MEditUser editUser);
        public Task<(IdentityResult, MIdentityUser)> CreateUser(MCreateUser createUser);
        public Task SendEmailVerificationMessage(MIdentityUser user);
    }
}
