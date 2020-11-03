using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Page.Models;

namespace YourSpace.Areas.Identity
{
    public class MIdentityRole : IdentityRole
    {
        public string StartProfileImage { get; set; } = "";
        public int MaxPagesAmount { get; set; } = 3;

        public int PageMaxBlocks { get; set; } = 0;
        public int PageMaxMainGroups { get; set; } = 0;
        public int PageMaxGroupDepth { get; set; } = 0;

        public void SetSettings(MPageSettings settings)
        {
            PageMaxBlocks = settings.MaxBlocks;
            PageMaxMainGroups = settings.MaxMainGroups;
            PageMaxGroupDepth = settings.MaxGroupDepth;
        }
    }
}
