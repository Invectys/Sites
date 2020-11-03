using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Blocks;

namespace YourSpace.Modules.Pages.Page
{
    public class MEditPage
    {
        public MPageCardBlock DisplayBlock { get; set; }

        public MEditPage()
        {
            DisplayBlock = new MPageCardBlock();
        }
    }
}
