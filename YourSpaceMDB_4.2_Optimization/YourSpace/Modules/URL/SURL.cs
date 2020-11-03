using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.ConfigurationModels;

namespace YourSpace.Modules.URL
{
    public class SURL
    {

        public string NotFound { get { return $"{_options.Domain}/notfound"; }  }


        MDefaultSettings _options;
        public SURL(IOptions<MDefaultSettings> options)
        {
            _options = options.Value;
        }

        public string Get(params string[] address) 
        {
            string domain = _options.Domain;
            if(address == null )
            {
                return domain;
            }
            string adr = Path.Combine(address);
            return Path.Combine(domain, adr);
        }

       


    }
}
