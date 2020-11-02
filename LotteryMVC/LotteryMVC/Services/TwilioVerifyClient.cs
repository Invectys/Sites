using LotteryMVC.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace LotteryMVC.Services
{
    public class TwilioVerifyClient
    {
        
        private readonly TwiloConfiguration _options;
        public TwilioVerifyClient(IOptions<TwiloConfiguration> options)
        {
            
            _options = options.Value;
        }

        public string StartVerification(int countryCode, string phoneNumber)
        {
            if (!_options.TwiloEnabled) return "NoEnabled";

            TwilioClient.Init(_options.AccountSid, _options.AuthToken);

            string To = "+" + countryCode + phoneNumber;

            var verification = VerificationResource.Create(
                to: To,
                channel: "sms",
                pathServiceSid: _options.VerifyServiceSid
            );

           

            return verification.Status;
        }

        public string CheckVerificationCode(int countryCode, string phoneNumber, string verificationCode)
        {
            if (!_options.TwiloEnabled) return "NoEnabled";

            TwilioClient.Init(_options.AccountSid, _options.AuthToken);
            string To = "+" + countryCode + phoneNumber;
            var verificationCheck = VerificationCheckResource.Create(
            to: To,
            code: verificationCode,
            pathServiceSid: _options.VerifyServiceSid
            );
           

            return verificationCheck.Status;
        }

        
    
}
}
