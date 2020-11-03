using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Resources.ValidationMessages;

namespace YourSpace.Modules.Music
{
    [Serializable]
    public class MMusic
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessageResourceName = "RequiredName", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(15,MinimumLength = 5, ErrorMessageResourceName = "MusicNameLength", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = "File is loading Wait...",ErrorMessageResourceType =typeof(ValidationMessages))]
        public string Path { get; set; }
        [Required(ErrorMessageResourceName = "RequiredImage", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string Image { get; set; }

        public string Author { get; set; }
        public string UserName { get; set; }
    }
}
