using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.ModalWindow;
using YourSpace.Services;

namespace YourSpace.Modules.Pages.Blocks.ModifyComponents
{
    public partial class EditBlock
    {
        [CascadingParameter] public ModalParameters Parameters { get; set; }
        private MPageBlock Block => Parameters.Get<MPageBlock>("Block");

        private void Continue()
        {
            Close(ModalResult.OK(Parameters));
        }

        public static new int GetDefaultModalId() => 1;
    }
}
