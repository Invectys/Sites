using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Services;
using YourSpace.Modules.Pages.Blocks;
using YourSpace.Modules.ModalWindow;
using YourSpace.Modules.Pages.Groups.ViewMode;
using YourSpace.Modules.Pages.Blocks.ModifyComponents;
using YourSpace.Modules.Pages.Page;
using System.ComponentModel;

namespace YourSpace.Modules.Pages.Blocks
{
    public class CPageBlock : ComponentBase
    {
        [Parameter] public MPageBlock Block { get; set; }
        
    }
}
