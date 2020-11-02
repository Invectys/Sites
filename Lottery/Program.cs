using System;
using System.IO;
using System.Threading.Tasks;
using Lottery.Interfaces;
using Lottery.Models;
using Lottery.Other;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Lottery
{
    public class Program
    {
        public static async Task  Main(string[] args)
        {

            IWebHost host = CreateWebHostBuilder(args).Build();


            


            //config 

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                
                
                try
                {
                    //roles and admins
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                 
                    await RoleInitializer.InitializeAsync(userManager, rolesManager);

                    //create game 
                    var opt = services.GetService<IOptionsMonitor<MainOptions>>();
                    var GamesControl = services.GetService<IGamesControl>();
                    MainOptions mainOptions = opt.CurrentValue;
                    foreach (var info in mainOptions.Games)
                    {
                        GamesControl.CreateNewGame(info);
                    }

                   
                   
                        


                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }





            host.Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
