using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Lottery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Lottery.Controllers
{
    public class MoneyController : Controller
    {

        UserManager<ApplicationUser> _userManager;
        MainOptions Options;
        public MoneyController(UserManager<ApplicationUser> manager, IOptionsMonitor<MainOptions> options)
        {
            _userManager = manager;
            Options = options.CurrentValue;

        }

        // GET: Money
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add()
        {

            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            user.Money += 100;
            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return StatusCode(200);
            }
            else return StatusCode(500);


        }


        public IActionResult Deposite()
        {

            //ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            //user.Money += 100;
            //IdentityResult result = await _userManager.updateAsync(user);
            //if (result.Succeeded)
            //{
            //    return StatusCode(200);
            //}
            //else return StatusCode(500);

            ViewBag.RoubleCourse = Options.OneRubbleInCatMoney;
            return View("Deposite");
        }

        public string DepositeOk()
        {

            //ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            //user.Money += 100;
            //IdentityResult result = await _userManager.updateAsync(user);
            //if (result.Succeeded)
            //{
            //    return StatusCode(200);
            //}
            //else return StatusCode(500);

            return "It is okey";
        }
        [HttpPost]
        public async Task DepositeOkAsync(string notification_type, string operation_id, string label, string datetime,
        decimal amount, decimal withdraw_amount, string sender, string sha1_hash, string currency, bool codepro)
        {
            string key = "5sjbhArGjOilThNu6ATFBRHV"; // секретный код

                                             // проверяем хэш
            string paramString = String.Format("{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}",
                notification_type, operation_id, amount, currency, datetime, sender,
                codepro.ToString().ToLower(), key, label);


            string paramStringHash1 = GetHash(paramString);


            // создаем класс для сравнения строк
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;


            //если хэши идентичны, добавляем данные о заказе в бд
            if (0 == comparer.Compare(paramStringHash1, sha1_hash))
            {
                ApplicationUser user = await _userManager.FindByNameAsync(label);
                if(user != null)
                {

                    user.Money += Options.OneRubbleInCatMoney * (int)amount;
                }
            }
        }


        public string GetHash(string val)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] data = sha.ComputeHash(Encoding.Default.GetBytes(val));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}