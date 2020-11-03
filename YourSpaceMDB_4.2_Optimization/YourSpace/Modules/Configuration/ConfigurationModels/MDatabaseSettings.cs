using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.ConfigurationModels
{
    public class MDatabaseSettings
    {
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public bool IntegratedSecurity { get; set; }
        public bool UseAuthorization { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool UseOtherConfiguration { get; set; }
        public string ConfigurationStringName { get; set; }
    }
}
