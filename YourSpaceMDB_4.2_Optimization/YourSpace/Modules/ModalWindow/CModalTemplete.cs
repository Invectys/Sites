using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Services;

namespace YourSpace.Modules.ModalWindow
{
    public class CModalTemplete : ComponentBase
    {
        [Parameter] public int ModalId { get; set; }

        [CascadingParameter] protected ModalParameters ModalParameters { get; set; }
        [Inject] protected ISModal SModal { get; set; }


        public void Close(ModalResult result)
        {
            SModal.Close(result, ModalId);
        }

        public void Cancel()
        {
            SModal.Cancel(ModalId);
        }
        public static int GetDefaultModalId() => 1;
    }
}
