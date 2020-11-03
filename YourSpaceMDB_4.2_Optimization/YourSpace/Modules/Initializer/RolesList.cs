using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;

namespace YourSpace.Modules.Initializer
{
    public static class RolesList
    {
        public static List<MIdentityRole> GetAllRoles()
        {
            return new List<MIdentityRole>() { User, Moderator, SuperModerator, Admin };
        }
        public static MIdentityRole User { 
            get
            {
                string name = "User";
                int MaxPages = 3;

                MIdentityRole role = new MIdentityRole();
                role.Name = name;
                role.NormalizedName = name.ToUpper();
                role.MaxPagesAmount = MaxPages;
                role.PageMaxBlocks = 5;
                role.PageMaxGroupDepth = 1;
                role.PageMaxMainGroups = 3;
                role.StartProfileImage = "";
                return role;
            }
        }
        public static MIdentityRole Moderator
        {
            get
            {
                string name = "Moderator";
                int MaxPages = 3;

                MIdentityRole role = new MIdentityRole();
                role.Name = name;
                role.NormalizedName = name.ToUpper();
                role.MaxPagesAmount = MaxPages;
                role.PageMaxBlocks = 5;
                role.PageMaxGroupDepth = 1;
                role.PageMaxMainGroups = 3;
                role.StartProfileImage = "";
                return role;
            }
        }

        public static MIdentityRole SuperModerator
        {
            get
            {
                string name = "SuperModerator";
                int MaxPages = 3;

                MIdentityRole role = new MIdentityRole();
                role.Name = name;
                role.NormalizedName = name.ToUpper();
                role.MaxPagesAmount = MaxPages;
                role.PageMaxBlocks = 5;
                role.PageMaxGroupDepth = 1;
                role.PageMaxMainGroups = 3;
                role.StartProfileImage = "";
                return role;
            }
        }

        public static MIdentityRole Admin
        {
            get
            {
                string name = "Admin";
                int MaxPages = 15;

                MIdentityRole role = new MIdentityRole();
                role.Name = name;
                role.NormalizedName = name.ToUpper();
                role.MaxPagesAmount = MaxPages;
                role.PageMaxBlocks = 5;
                role.PageMaxGroupDepth = 1;
                role.PageMaxMainGroups = 3;
                role.StartProfileImage = "";
                return role;
            }
        }


    }
}
