using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.ThingCounter
{
    public class MCounterNote
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string DistId { get; set; }
        public string Page { get; set; }
    }
}
