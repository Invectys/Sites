using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Attributes;
using YourSpace.Modules.Pages.Blocks.Components;

namespace YourSpace.Modules.Pages.Blocks
{
    [Serializable]
    public class MTextBlock : MPageBlock
    {
        [AttributeSettingPageBlock("Text")]
        public string Text { get; set; }

        public override Type GetBlazorComponentDisplayType()
        {
            return typeof(TextBlockDisplay);
        }

        public override Type GetBlazorComponentType()
        {
            return typeof(TextBlock);
        }

        public override BlockCategories GetCategorie()
        {
            return BlockCategories.Social;
        }
    }
}
