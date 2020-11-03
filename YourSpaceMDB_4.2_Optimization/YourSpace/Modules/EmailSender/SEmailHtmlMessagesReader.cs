using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YourSpace.Modules.Configuration;
using YourSpace.Modules.Localization;

namespace YourSpace.Modules.EmailSender
{
    public class SEmailHtmlMessagesReader
    {
        private string _confirmEmailMessage;

        LEmailMessages _l;
        IHostEnvironment _hostEnvironment;
        

        public SEmailHtmlMessagesReader(IHostEnvironment hostEnvironment, LEmailMessages l)
        {
            _hostEnvironment = hostEnvironment;
            _l = l;

            _confirmEmailMessage = ReadConfirmEmailHTML();
        }

        public string GetConfirmEmailMessage(string url)
        {
            string message = _confirmEmailMessage;
            string title = _l["EmailConfirmTitle"];
            string link = _l["EmailConfirmLink"];
            message = String.Format(message, title, url, link);
            return message;
        }

        private string ReadConfirmEmailHTML()
        {
            string path = Path.Combine(_hostEnvironment.ContentRootPath, ConfigurationPaths.SettingsAppFolder, "EmailMessages","ConfirmEmailMessage.html");
            string message = "";
            using (var stream = new StreamReader(path))
            {
                message = stream.ReadToEnd();
            }
            return message;
        }
    }
}
