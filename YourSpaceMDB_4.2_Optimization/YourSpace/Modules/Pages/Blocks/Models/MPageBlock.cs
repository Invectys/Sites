using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YourSpace.Modules.Pages.Blocks.Models;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Modules.Pages.Blocks
{
    [Serializable]
    [XmlInclude(typeof(MGroupBlock))]
    [XmlInclude(typeof(MMusicBlock))]
    [XmlInclude(typeof(MLikeBlock))]
    [XmlInclude(typeof(MSubscribeBlock))]
    [XmlInclude(typeof(MEmailSendBlock))]
    [XmlInclude(typeof(MPageCardBlock))]
    [XmlInclude(typeof(MImageBlock)), XmlInclude(typeof(MTextBlock))]
    public abstract class MPageBlock 
    {

        public string UniqueId { get; set; }

        //[XmlIgnore]
        //[NotMapped]
        public string PageId { get; set; }
        [XmlIgnore]
        [NotMapped]
        public MBlocksGroup ParentGroup { get; set; }

        public abstract BlockCategories GetCategorie();
        public abstract Type GetBlazorComponentType();
        public abstract Type GetBlazorComponentDisplayType();
    }

    
}
