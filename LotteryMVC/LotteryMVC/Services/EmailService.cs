using LotteryMVC.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryMVC.Services
{
    public class EmailService
    {
        EmailConfiguration _options;
        public EmailService(IOptions<EmailConfiguration> options)
        {
            _options = options.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            if (!_options.EmailEnabled) return ;
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_options.FromName, _options.FromAddress));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_options.SmptHost, _options.SmptPort, false);
                await client.AuthenticateAsync(_options.AuthMail, _options.Password);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
