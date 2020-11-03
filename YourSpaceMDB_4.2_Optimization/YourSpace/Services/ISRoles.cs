using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;

namespace YourSpace.Services
{
    public interface ISRoles
    {
        public Task<List<MIdentityRole>> GetAll();
        public Task<List<string>> GetAllNames();
        
        public Task SetRole(string userId, string roleName);
        public Task SetRole(MIdentityUser user, string roleName);
        public Task<MIdentityRole> GetRole(string userId);
        public Task<MIdentityRole> GetRole(MIdentityUser user);
        public Task DeleteRole(string role, string changeToRole);
        public bool CanDeleteRole(string role);
        public Task UpdateRole(string roleName);

        public Task UpdateRole(MIdentityRole role);
        

    }
}
