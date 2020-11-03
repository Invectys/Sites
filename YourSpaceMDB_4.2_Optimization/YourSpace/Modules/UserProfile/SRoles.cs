using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Modules.Initializer;
using YourSpace.Services;

namespace YourSpace.Modules.UserProfile
{
    public class SRoles : ISRoles
    {
        UserManager<MIdentityUser> _userManager;
        RoleManager<MIdentityRole> _roleManager;
        ISPages _sPages;

        public SRoles(UserManager<MIdentityUser> userManager, RoleManager<MIdentityRole> roleManager, ISPages sPages)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _sPages = sPages;
        }
        public async Task<List<MIdentityRole>> GetAll()
        {
            return await _roleManager.Roles.ToListAsync();
        }
        public async Task<List<string>> GetAllNames()
        {
            return await _roleManager.Roles.Select(r=>r.Name).ToListAsync();
        }
        public async Task SetRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await SetRole(user, roleName);
        }
        public async Task SetRole(MIdentityUser user, string roleName)
        {
            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);
            await _userManager.AddToRoleAsync(user, roleName);
            var setedRole = await _roleManager.FindByNameAsync(roleName);
            await _userManager.UpdateAsync(user);


            //Update pages restrictions
            var pages = _sPages.GetUserPages(user);
            foreach(var p in pages)
            {
                p.SetInfo(setedRole);
            }
        }

        public async Task<MIdentityRole> GetRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return await GetRole(user);
        }
        public async Task<MIdentityRole> GetRole(MIdentityUser user)
        {
            List<string> list = (await _userManager.GetRolesAsync(user)).ToList();
            MIdentityRole role = await _roleManager.FindByNameAsync(list[0]);
            return role;
        }
        public async Task UpdateRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            await UpdateRole(role);
        }
        public async Task UpdateRole(MIdentityRole role)
        {
            await _roleManager.UpdateAsync(role);
        }

        public bool CanDeleteRole(string role)
        {
            bool contain = RolesList.GetAllRoles().Select(r => r.Name).Contains(role);
            return !contain;
        }

        public async Task DeleteRole(string role,string changeToRole)
        {
           var users = await _userManager.GetUsersInRoleAsync(role);
           foreach(var user in users)
           {
                await SetRole(user, changeToRole);
           }

            var r = await _roleManager.FindByNameAsync(role);
            await _roleManager.DeleteAsync(r);
        }
    }
}
