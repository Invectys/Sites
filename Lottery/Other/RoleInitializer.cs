using Lottery.Data;
using Lottery.Models;
using Lottery.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Other
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminName = "Invectys";
            string adminEmail = "qzwsecrftb@gmail.com";
            string password = "qzwsecrftb1";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("moderator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("moderator"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await roleManager.FindByNameAsync("publicist") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("publicist"));
            }
            if (await userManager.FindByNameAsync(adminName) == null)
            {
                ApplicationUser admin = new ApplicationUser { Email = adminEmail, UserName = adminName };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                    await userManager.AddToRoleAsync(admin, "moderator");
                }
            }
        }
    }
}
