using Lottery.Interfaces;
using Lottery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Games
{
    public class Class1 : IMyInterface
    {
        private readonly ILogger<Class1> _logger;
        private readonly UserManager<ApplicationUser> _usermanager;
        public Class1(ILogger<Class1> logger,UserManager<ApplicationUser> manager)
        {
            _logger = logger;
            _usermanager = manager;
        }

        public Task Write()
        {
            _logger.LogInformation(
                "MyDependency.WriteMessage called. Message: {MESSAGE}",
                "Hello methode");

            return Task.FromResult(0);
        }
    }
}
