using Lottery.Models;
using Lottery.Models.OptionsModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lottery.Other
{
    public class GoogleCaptchaService
    {
        IHttpClientFactory _httpClientFactory;
        GoogleCaptchaSettings CaptchaSettings;
        private string SecretCaptchaKey;
        private string CaptchaServiceUrl = "https://www.google.com/recaptcha/api/siteverify";
        private bool Enable;
        public GoogleCaptchaService(IHttpClientFactory httpClientFactory,IOptionsMonitor<GoogleCaptchaSettings> Captcha)
        {
            _httpClientFactory = httpClientFactory;
            CaptchaSettings = Captcha.CurrentValue;
            SecretCaptchaKey = CaptchaSettings.GoogleReCaptchaSecret;
            Enable = CaptchaSettings.GoogleReCaptchaEnable;
        }

        public async Task<bool> VerifyCaptchaAsync(string Token,string addr)
        {
            if (!Enable) return true;

            try
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("secret", SecretCaptchaKey);
                pairs.Add("response", Token);
                pairs.Add("remoteip", addr);
                var content = new FormUrlEncodedContent(pairs);

                string json = JsonConvert.SerializeObject(pairs);
                var request = new HttpRequestMessage(HttpMethod.Post, CaptchaServiceUrl);
                request.Content = content;

                var client = _httpClientFactory.CreateClient();
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string str = response.Content.ReadAsStringAsync().Result;
                    pairs.Clear();
                    pairs = JsonConvert.DeserializeObject<Dictionary<string, string>>(str);

                    string result, action, score;
                    bool ok = pairs.TryGetValue("success", out result);
                    bool ok1 = pairs.TryGetValue("action", out action);
                    bool ok2 = pairs.TryGetValue("score", out score);
                    if (ok && ok1 && ok2 && result.Equals("true"))
                    {
                        float _score = float.Parse(score,CultureInfo.InvariantCulture);
                        if (_score > 0.5) return true;//humman
          
                    }
                    else
                    {
                        return false;//bot
                    }
                }
            }catch(Exception e)
            {

            }
           

            return false;
        }
    }
}
