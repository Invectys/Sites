using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using YourSpace.Resources;

namespace YourSpace.Modules.Localization
{
    public class LBlocksInfo
    {
        private readonly IStringLocalizer _localizer;
        public LBlocksInfo(IStringLocalizerFactory factory)
        {
            var assemblyName = new AssemblyName(typeof(RBlocks).GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create(nameof(RBlocks), assemblyName.Name);
        }

        public string this[string key]
        {
            get
            {
                return _localizer[key];
            }
        }
    }
}
