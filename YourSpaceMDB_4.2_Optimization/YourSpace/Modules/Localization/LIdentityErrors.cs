using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using YourSpace.Resources;

namespace YourSpace.Modules.Localization
{
    public class LIdentityErrors
    {
        private IStringLocalizer _localizer;
        public LIdentityErrors(IStringLocalizerFactory factory)
        {
            var assemblyName = new AssemblyName(typeof(RErrorDescriber).GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create(nameof(RErrorDescriber), assemblyName.Name);
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
