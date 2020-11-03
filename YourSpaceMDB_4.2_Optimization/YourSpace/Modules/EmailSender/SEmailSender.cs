using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.ConfigurationModels;
using YourSpace.Modules.Localization;

namespace YourSpace.Modules.EmailSender
{
    public class SEmailSender : IEmailSender
    {
        MEmailSettings _options;
        LEmailMessages _l;


        public SEmailSender(LEmailMessages l,IOptions<MEmailSettings> emailOptions)
        {
            _l = l;
            _options = emailOptions.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            var emailMessage = new MimeMessage();
            string name = _l["FromTitle1"];
            string fromEmail = _options.Login;
            emailMessage.From.Add(new MailboxAddress(name, fromEmail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = htmlMessage
            };
            
            using(var smtpClient = new SmtpClient())
            {
                

                await smtpClient.ConnectAsync(_options.MailUrl, _options.SmtpPort, true);
                await smtpClient.AuthenticateAsync(_options.Login, _options.Password);
                await smtpClient.SendAsync(emailMessage);

                await smtpClient.DisconnectAsync(true);
            }

        }
    }
}
