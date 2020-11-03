using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using YourSpace.Resources;

namespace YourSpace.Modules.Localization
{
    public class LGroupsInfo
    {
        private IStringLocalizer _localizer;
        public LGroupsInfo(IStringLocalizerFactory factory)
        {
            var assemblyName = new AssemblyName(typeof(RGroups).GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create(nameof(RGroups), assemblyName.Name);
        }

        public string this[string key]
        {
            get
            {
                return _localizer.GetString(key);
            }
        }
    }
}
