using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Differencing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Moderation;
using YourSpace.Modules.Moderation.Models;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Areas.Identity
{
    public class MIdentityUser : IdentityUser
    {
        public MUserProfile UserProfile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void ApplyEditUser(MEditUser editUser)
        {
            FirstName = editUser.FirstName;
            LastName = editUser.LastName;
            Email = editUser.Email;
        }
        public void ApplyCreateUser(MCreateUser createUser)
        {
            FirstName = createUser.FirstName;
            LastName = createUser.LastName;
            UserName = createUser.Email;
            Email = createUser.Email;
            EmailConfirmed = createUser.EmailConfirmed;
        }
        public MEditUser GetEditUser()
        {
            MEditUser editUser = new MEditUser();
            editUser.FirstName = FirstName;
            editUser.LastName = LastName;
            editUser.Email = Email;
            return editUser;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

    }
    public class MUserProfile
    {
        [Key]
        public string UserId { get; set; }
        

        public MIdentityUser User { get; set; }
        public ICollection<MPageInfo> Pages { get; set; }

        public string ProfileImage { get; set; }

        
    }

    
}
