using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.Pages.Page.Models
{
    public class MPageSettings
    {
        public int MaxBlocks { get; set; }
        public int MaxMainGroups { get; set; }
        public int MaxGroupDepth { get; set; }
        public string DefaultPageImage { get; set; }
    }
}
