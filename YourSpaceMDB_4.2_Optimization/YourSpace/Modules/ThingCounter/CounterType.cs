using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Pages;

namespace YourSpace.Modules.ThingCounter
{
    public class MCounterType
    {
        public virtual bool IsSubscribe { get; } = false;
        public virtual bool IsLike { get; } = false;

        public static MCounterType Subscribe()
        {
            return new MCounterSubscribe();
        }

        public static MCounterType Like()
        {
            return new MCounterLike();
        }
    }
    public class MCounterSubscribe : MCounterType
    {
        public override bool IsSubscribe { get; } = true;
    }
    public class MCounterLike : MCounterType
    {
        public override bool IsLike { get; } = true;
    }
}
