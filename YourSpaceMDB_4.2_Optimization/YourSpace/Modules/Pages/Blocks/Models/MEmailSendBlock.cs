using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Attributes;
using YourSpace.Modules.Pages.Blocks.Components;

namespace YourSpace.Modules.Pages.Blocks.Models
{
    [Serializable]
    public class MEmailSendBlock : MPageBlock
    {
        [AttributeSettingPageBlock("Email")] public string Email { get; set; }

        public override Type GetBlazorComponentDisplayType()
        {
            return typeof(EmailSendBlockDisplay);
        }

        public override Type GetBlazorComponentType()
        {
            return typeof(EmailSendBlock);
        }

        public override BlockCategories GetCategorie()
        {
            return BlockCategories.Other;
        }
    }
}
