using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Configuration.ConfigurationModels;
using YourSpace.Modules.ConfigurationModels;
using YourSpace.Modules.Localization;
using YourSpace.Modules.Pages.Page.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationConfigurationModels(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MPageSettings>(configuration.GetSection("page-default"));
            services.Configure<MCacheSettings>(configuration.GetSection("cache-time"));
            services.Configure<MDefaultSettings>(configuration.GetSection("default"));
            services.Configure<MRootAccountSettings>(configuration.GetSection("owner-account"));
            services.Configure<MEmailSettings>(configuration.GetSection("mail"));
            services.Configure<MDatabaseSettings>(configuration.GetSection("database"));
            services.Configure<MLoadingSettings>(configuration.GetSection("loading"));
        }

        public static void AddApplicationLocalization(this IServiceCollection services)
        {
            services.AddSingleton<LBlocksInfo>();
            services.AddSingleton<LGroupsInfo>();
            services.AddSingleton<LEmailMessages>();
            services.AddSingleton<LIdentityErrors>();
            services.AddSingleton<LPage>();
        }
    }
}
