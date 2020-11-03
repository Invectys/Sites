using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Blocks.Components;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Modules.Pages.Blocks.Models
{
    [Serializable]
    public class MGroupBlock : MPageBlock
    {
        public MBlocksGroup ContainGroup { get; set; }
        public override Type GetBlazorComponentDisplayType()
        {
            return typeof(ContainerBlockDisplay);
        }
        public override Type GetBlazorComponentType()
        {
            throw new NotImplementedException();
        }
        public override BlockCategories GetCategorie()
        {
            return BlockCategories.Other;
        }
    }
}
