using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Modules.ModalWindow;
using YourSpace.Services;

namespace YourSpace.Modules.Moderation
{
    public partial class EditUserRole
    {
        public string UserId { get; set; }
        public static new int GetDefaultModalId() => 1;

        private MRoleEdit _editUserRole = new MRoleEdit();

        [Inject] protected RoleManager<MIdentityRole> SRoleManager { get; set; }
        [Inject] protected ISRoles SRoles { get; set; }
        [Inject] protected ISUserProfile SProfile { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UserId = ModalParameters.Get<string>("UserId");
        }

        async void Submit()
        {

            await SRoles.SetRole(UserId, _editUserRole.Role);
            if (_editUserRole.UpdateProfile)
            {
                await SProfile.RemoveProfile(UserId);
                await SProfile.InitUserProfile(UserId);
            }
            Close(ModalResult.OK("ok"));
        }


        class MRoleEdit
        {
            [Required]
            public string Role { get; set; }
            public bool UpdateProfile { get; set; } = true;
        }
    }
}
