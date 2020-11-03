using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Initializer;
using YourSpace.Resources.ValidationMessages;

namespace YourSpace.Modules.Moderation.Models
{
    public class MCreateUser
    {
        [Required(ErrorMessageResourceName= "RequiredFirstName", ErrorMessageResourceType=typeof(ValidationMessages))]
        public string FirstName { get; set; }
        public string LastName { get; set; } = "";
        [Required(ErrorMessageResourceName = "RequiredEmail", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessageResourceName = "RequiredPassword", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessageResourceName = "RequiredRole", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string Role { get; set; } = RolesList.User.Name;

        public bool EmailConfirmed { get; set; } = false;
    }
}
