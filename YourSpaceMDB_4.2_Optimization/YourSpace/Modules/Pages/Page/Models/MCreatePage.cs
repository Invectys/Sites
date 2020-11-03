using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Blocks;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Modules.Pages.Page
{
    public class MCreatePage : MEditPage
    {
        [Required(ErrorMessageResourceName = "RequiredPageUrl", ErrorMessageResourceType =typeof(YourSpace.Resources.ValidationMessages.ValidationMessages))]
        [StringLength(10,MinimumLength = 3, ErrorMessageResourceName = "PageUrlLength", ErrorMessageResourceType = typeof(YourSpace.Resources.ValidationMessages.ValidationMessages))]
        public string Url { get; set; }
        
    }

   
}
