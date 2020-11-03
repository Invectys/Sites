using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Blocks.Components;

namespace YourSpace.Modules.Pages.Blocks.Models
{
    [Serializable]
    public class MLikeBlock : MPageBlock
    {
        [NotMapped]
        public int Likers { get; set; }

        public override Type GetBlazorComponentDisplayType()
        {
            return typeof(LikeBlockDisplay);
        }

        public override Type GetBlazorComponentType()
        {
            return typeof(LikeBlock);
        }

        public override BlockCategories GetCategorie()
        {
            return BlockCategories.Marks;
        }
    }
}
