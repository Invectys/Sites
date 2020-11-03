using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using YourSpace.Resources;

namespace YourSpace.Modules.Localization
{
    public class LEmailMessages
    {
        private IStringLocalizer _localizer;
        public LEmailMessages(IStringLocalizerFactory factory)
        {
            var assemblyName = new AssemblyName(typeof(REmail).GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create(nameof(REmail), assemblyName.Name);
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
