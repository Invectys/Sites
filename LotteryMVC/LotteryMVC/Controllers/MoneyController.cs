using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotteryMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LotteryMVC.Controllers
{
    public class MoneyController : Controller
    {
        MoneyConfiguration _options;
        public MoneyController(IOptions<MoneyConfiguration> options)
        {
            _options = options.Value;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Deposite()
        {
            return View();
        }
        public IActionResult Withdraw()
        {
            return View();
        }
    }
}