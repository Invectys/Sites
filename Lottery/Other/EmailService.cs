using Lottery.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Other
{
    public class EmailService
    {
        MainOptions opt;
        public EmailService(IOptionsMonitor<MainOptions> options)
        {
            opt = options.CurrentValue;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(opt.MailTheme, opt.FromMailBox));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(opt.smpt_host,opt.smpt_port, false);
                await client.AuthenticateAsync(opt.smpt_login, opt.smpt_password);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);

            }
        }
    }
}
