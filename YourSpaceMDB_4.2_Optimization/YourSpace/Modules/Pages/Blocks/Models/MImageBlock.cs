using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Attributes;
using YourSpace.Modules.Pages.Blocks.Components;

namespace YourSpace.Modules.Pages.Blocks
{
    [Serializable]
    public class MImageBlock : MPageBlock
    {

        [AttributeSettingPageBlock("Image")]
        public string ImagePath { get; set; }

        public override Type GetBlazorComponentDisplayType()
        {
            return typeof(ImageBlockDisplay);
        }

        public override Type GetBlazorComponentType()
        {
            return typeof(ImageBlock);
        }

        public override BlockCategories GetCategorie()
        {
            return BlockCategories.Social;
        }
    }
}
