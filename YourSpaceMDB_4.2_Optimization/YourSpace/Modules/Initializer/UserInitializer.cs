using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Data;
using YourSpace.Modules.ConfigurationModels;
using YourSpace.Services;

namespace YourSpace.Modules.Initializer
{
    public class UserInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext dbContext,
            UserManager<MIdentityUser> userManager, RoleManager<MIdentityRole> roleManager,
            ISUserProfile sUserProfile, MRootAccountSettings rootAccount)
        {
            var list = roleManager.Roles;
            foreach(var role in RolesList.GetAllRoles())
            {
                if (!await roleManager.RoleExistsAsync(role.Name))
                {
                    await roleManager.CreateAsync(role);
                }
            }
           
            
            string ownerId = rootAccount.AccountId == "" ? Guid.NewGuid().ToString() : rootAccount.AccountId;
            string ownerEmail = rootAccount.Email;
            string ownerPassword = rootAccount.Password;
            
            if (await userManager.FindByNameAsync(ownerEmail) == null)
            {
                MIdentityUser admin = new MIdentityUser
                {   
                    Id = ownerId,
                    Email = ownerEmail,
                    UserName = ownerEmail,
                    FirstName = "Artem",
                    EmailConfirmed = true
                };
                

                IdentityResult result = await userManager.CreateAsync(admin, ownerPassword);

                await userManager.AddToRoleAsync(admin, RolesList.Admin.Name);
                await sUserProfile.InitUserProfile(admin);
            }
        }

    }
}
