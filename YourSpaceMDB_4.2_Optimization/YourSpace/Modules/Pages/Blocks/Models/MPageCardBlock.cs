using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Attributes;
using YourSpace.Modules.Pages.Blocks.Components;
using YourSpace.Resources.ValidationMessages;

namespace YourSpace.Modules.Pages.Blocks
{
    public static class PageCardBlockValues
    {
        public const int MaxTitleLength = 15;
        public const int MaxTextDescription = 400;
    }


    [Serializable]
    public class MPageCardBlock : MPageBlock
    {

        [NotMapped]
        public bool ShowEditLink { get; set; } = false;


        [Required(ErrorMessageResourceName = "RequiredPageTitle", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(PageCardBlockValues.MaxTitleLength, 
            ErrorMessageResourceName = "LengthPageTitle", ErrorMessageResourceType = typeof(ValidationMessages))]
        [AttributeSettingPageBlock("PageTitle")] 
        public string Title { get; set; }


        [AttributeSettingPageBlock("PageBackground")] 
        public string ImageBackground { get; set; }


        [StringLength(maximumLength: PageCardBlockValues.MaxTextDescription, 
            ErrorMessageResourceName = "LengthPageDescription", ErrorMessageResourceType = typeof(ValidationMessages))]
        [AttributeSettingPageBlock("PageDescription")] 
        public string TextDescription { get; set; }

        public string Name { get; set; }

        public MPageCardBlock()
        {
            Title = "";
            ImageBackground = "";
            TextDescription = "";
        }
        public override Type GetBlazorComponentType()
        {
            return typeof(PageCardBlock);
        }

        public override Type GetBlazorComponentDisplayType()
        {
            throw new NotImplementedException();
        }

        public override BlockCategories GetCategorie()
        {
            return BlockCategories.Other;
        }

       
    }
}
