using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotteryMVC.Data;
using LotteryMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace LotteryMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();


            //const string AccountSid = "AC9c6818bcbed65af9bbc9766cc52927ed";
            //const string AccountToken = "43c629c6ee2d704fefdec80fd248e57a";

            //TwilioClient.Init(AccountSid, AccountToken);
            //var msg = MessageResource.Create(
            //    body: "Fuck you",
            //    from: new Twilio.Types.PhoneNumber("+17249184174"),
            //    to: new Twilio.Types.PhoneNumber("+79774140029")
            //    );
            //Console.WriteLine(msg.Sid);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    DBInizializer.InitializeAsync(userManager, rolesManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
