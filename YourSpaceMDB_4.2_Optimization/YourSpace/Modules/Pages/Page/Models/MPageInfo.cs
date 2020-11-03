using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Modules.Pages.Blocks;
using YourSpace.Modules.Pages.Page.Models;

namespace YourSpace.Modules.Pages.Page
{
    public class MPageInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string UserProfileId { get; set; }
        public MUserProfile UserProfile { get; set; }



        public int MaxMainGroups { get; set; } = 10;
        public int MaxBlocks { get; set; } = 10;
        public int MaxDepth { get; set; } = 1;

        public void SetInfo(MPageSettings pageSettings)
        {
            MaxMainGroups = pageSettings.MaxMainGroups;
            MaxBlocks = pageSettings.MaxBlocks;
            MaxDepth = pageSettings.MaxGroupDepth;
        }
        public void SetInfo(MIdentityRole role)
        {
            MaxMainGroups = role.PageMaxMainGroups;
            MaxBlocks = role.PageMaxBlocks;
            MaxDepth = role.PageMaxGroupDepth;
        }
    }
}
