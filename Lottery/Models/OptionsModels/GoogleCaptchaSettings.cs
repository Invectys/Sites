using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models.OptionsModels
{
    public class GoogleCaptchaSettings
    {
        public string GoogleReCaptchaSecret { get; set; }
        public string GoogleReCaptchaPublic { get; set; }
        public bool GoogleReCaptchaEnable { get; set; }
    }
}
