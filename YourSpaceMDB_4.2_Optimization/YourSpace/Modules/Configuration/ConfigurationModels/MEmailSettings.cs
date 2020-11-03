using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.ConfigurationModels
{
    public class MEmailSettings
    {
        public string MailUrl { get; set; }
        public int SmtpPort { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
