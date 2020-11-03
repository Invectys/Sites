using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Blocks.Components;

namespace YourSpace.Modules.Pages.Blocks.Models
{
    [Serializable]
    public class MSubscribeBlock : MPageBlock
    {
        [NotMapped]
        public int Subscribers { get; set; }

        public override Type GetBlazorComponentDisplayType()
        {
            return typeof(SubscribeBlockDisplay);
        }

        public override Type GetBlazorComponentType()
        {
            return typeof(SubscribeBlock);
        }

        public override BlockCategories GetCategorie()
        {
            return BlockCategories.Marks;
        }
    }
}
