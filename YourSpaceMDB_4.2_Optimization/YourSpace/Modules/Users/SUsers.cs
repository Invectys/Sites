using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Data;
using YourSpace.Modules.Moderation.Models;
using YourSpace.Services;

namespace YourSpace.Modules.Users
{
    public class SUsers : ISUsers
    {
        private int usersAmount = 10;

        UserManager<MIdentityUser> _userManager;
        ApplicationDbContext _dbContext;

        public SUsers(UserManager<MIdentityUser> userManager,ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<List<MIdentityUser>> GetUsers(int page, MUserFilter filter)
        {
            IQueryable<MIdentityUser> users = _userManager.Users;

            if (filter != null)
            {
                if (filter.Email != "")
                    users = _userManager.Users.Where(u => u.Email.Contains(filter.Email));
                if (filter.FirstName != "")
                    users = _userManager.Users.Where(u => u.FirstName.Contains(filter.FirstName));
            }

            List<MIdentityUser> list = await users.Skip(page * usersAmount).Take(usersAmount).ToListAsync();
            return list;
        }

        public int GetTotalPagesUsers()
        {
            int count = _userManager.Users.Count();
            return count / usersAmount;
        }

    }
}
