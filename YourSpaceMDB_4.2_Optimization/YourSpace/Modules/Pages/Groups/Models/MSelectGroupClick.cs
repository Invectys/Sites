﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Groups.ViewMode;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Modules.Pages.Groups.Models
{
    public class MSelectGroupClick
    {
        public CGroupDisplay Component { get; set; }
        public BlockGroupViewMode GroupView { get; set; }
    }
}
