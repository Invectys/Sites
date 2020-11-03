using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Pkix;
using YourSpace.Areas.Identity;
using YourSpace.Modules.Configuration;
using YourSpace.Modules.Initializer;

namespace YourSpace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(ConfigureAppConfiguration)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

        private static void ConfigureAppConfiguration(HostBuilderContext hostBuilderContext, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();

            var env = hostBuilderContext.HostingEnvironment;

            var str = ConfigurationPaths.SettingsAppFolder + "//settings";
            builder.AddIniFile($"{str}.ini", optional: true, reloadOnChange: true);
            builder.AddIniFile($"{str}.{env.EnvironmentName}.ini", optional: true, reloadOnChange: true);
        }
    }
}
