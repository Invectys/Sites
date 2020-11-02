using Lottery.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public float Money { get; set; }

        
        public int? InformationId { get; set; }
        public OtherUserInformationModel Information { get; set; }

        public ApplicationUser()
        {
            Information = new OtherUserInformationModel();
        }
    }
}
