using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Attributes;
using YourSpace.Modules.Music;
using YourSpace.Modules.Pages.Blocks.Components;

namespace YourSpace.Modules.Pages.Blocks.Models
{
    [Serializable]
    public class MMusicBlock : MPageBlock
    {
       

        [AttributeSettingPageBlock("Music")]
        public MMusic Music { get; set; } = new MMusic();

        public override Type GetBlazorComponentDisplayType()
        {
            return typeof(MusicBlockDisplay);
        }

        public override Type GetBlazorComponentType()
        {
            return typeof(MusicBlock);
        }

        public override BlockCategories GetCategorie()
        {
            return BlockCategories.Social;
        }
    }
}
