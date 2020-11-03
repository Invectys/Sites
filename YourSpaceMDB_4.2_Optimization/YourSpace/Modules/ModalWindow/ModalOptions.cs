using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.ModalWindow
{
    public class ModalOptions
    {
        public string Size { get; set; }
        public string Position { get; set; }
        public string Style { get; set; }
        public bool? DisableBackgroundCancel { get; set; }
        public bool? HideHeader { get; set; }
        public bool? HideCloseButton { get; set; }
    }
}
