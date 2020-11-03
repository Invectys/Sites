using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Modules.Moderation.Models;

namespace YourSpace.Services
{
    public interface ISUsers
    {
        public Task<List<MIdentityUser>> GetUsers(int page, MUserFilter filter = null);
        public int GetTotalPagesUsers();
        
    }
}
