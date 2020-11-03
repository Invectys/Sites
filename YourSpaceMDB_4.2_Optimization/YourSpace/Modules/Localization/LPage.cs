using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using YourSpace.Resources;

namespace YourSpace.Modules.Localization
{
    public class LPage
    {
        private IStringLocalizer _localizer;
        public LPage(IStringLocalizerFactory factory)
        {
            var assemblyName = new AssemblyName(typeof(RPage).GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create(nameof(RPage), assemblyName.Name);
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
