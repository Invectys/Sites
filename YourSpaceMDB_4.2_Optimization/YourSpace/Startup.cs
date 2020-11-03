using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YourSpace.Areas.Identity;
using YourSpace.Data;
using YourSpace.Services;
using YourSpace.Modules.FilesPathBuilder;
using Microsoft.AspNetCore.Authorization;
using YourSpace.Modules.Authorization;
using YourSpace.Modules.Pages.Page;
using Microsoft.AspNetCore.Components.Server;
using YourSpace.Modules.ModalWindow;
using YourSpace.Modules.FileUpload;
using YourSpace.Modules.PageReader;
using Microsoft.AspNetCore.Identity.UI.Services;
using YourSpace.Modules.EmailSender;
using System.Data.Common;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using YourSpace.Modules.Initializer;
using YourSpace.Modules.Authorization.Requirements;
using YourSpace.Modules.Pages.Groups;
using YourSpace.Modules.Pages.Blocks;
using YourSpace.Modules.ThingCounter;
using YourSpace.Modules.Moderation;
using YourSpace.Modules.Pages.Page.Services;
using YourSpace.Modules.Users;
using YourSpace.Modules.Rating;
using YourSpace.Modules.UserProfile;
using YourSpace.Modules.FileSave;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using YourSpace.Modules.Localization;
using System.IO;
using YourSpace.Modules.Music;
using YourSpace.Modules.Pages.Page.Models;
using Microsoft.CodeAnalysis.Options;
using YourSpace.Modules.ConfigurationModels;
using YourSpace.Resources;
using Microsoft.Extensions.Options;
using YourSpace.Pages;
using YourSpace.Modules.URL;
using YourSpace.Modules.Configuration;
using YourSpace.Modules.Configuration.ConfigurationModels;
using YourSpace.Modules.Browser;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace YourSpace
{
    public class Startup
    {
        public Startup(IConfiguration configuration,IHostEnvironment environment)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {


            services.AddServerSideBlazor();
            services.AddRazorPages();

            //configuration
            services.AddApplicationConfigurationModels(Configuration);
            services.AddTransient<IConfiguration>(provider => Configuration);

            //localization
            services.AddLocalization(options => {
                options.ResourcesPath = "Resources";
            });
            //services.AddResponseCompression(options => options.EnableForHttps = true);
            services.AddApplicationLocalization();
            services.AddMemoryCache();


            //Database initializator Connect to SQL server
            {
                var databaseConf = Configuration.GetSection("database");
                var useOtherConf = databaseConf.GetValue<bool>("UseOtherConfiguration");
                var OtherConfName = databaseConf.GetValue<string>("ConfigurationStringName");
                var dataSource = databaseConf.GetValue<string>("DataSource");
                var database = databaseConf.GetValue<string>("InitialCatalog");
                var userId = databaseConf.GetValue<string>("UserId");
                var password = databaseConf.GetValue<string>("Password");
                bool useAuthorization = databaseConf.GetValue<bool>("UseAuthorization");
                SqlConnectionStringBuilder sqlConn = new SqlConnectionStringBuilder();
                sqlConn.DataSource = dataSource;
                sqlConn.Add("Initial Catalog", database);
                if(useAuthorization)
                {
                    sqlConn.Add("User Id", userId);
                    sqlConn.Add("Password", password);
                }
                sqlConn.IntegratedSecurity = databaseConf.GetValue<bool>("IntegratedSecurity");
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(useOtherConf ? Configuration.GetConnectionString(OtherConfName) : sqlConn.ConnectionString)
                , ServiceLifetime.Scoped);
            }

            //Registration Identity
            {
                var identityConf = Configuration.GetSection("Identity");
                services.AddIdentity<MIdentityUser,MIdentityRole>(options => 
                {
                    options.SignIn.RequireConfirmedAccount = identityConf.GetValue<bool>("RequireConfirmedAccount");
                    options.Password.RequireLowercase = identityConf.GetValue<bool>("PasswordRequireLowercase");
                    options.Password.RequireUppercase = identityConf.GetValue<bool>("PasswordRequireUppercase");
                    options.Password.RequireDigit = identityConf.GetValue<bool>("PasswordRequireDigit");
                    options.Password.RequiredLength = identityConf.GetValue<int>("PasswordRequiredLength");
                    options.Password.RequireNonAlphanumeric = identityConf.GetValue<bool>("PasswordRequireNonAlphanumeric");
                    options.Password.RequiredUniqueChars = identityConf.GetValue<int>("PasswordRequiredUniqueChars");
                    options.Lockout.MaxFailedAccessAttempts = 6;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddErrorDescriber<ErrorDescriber>()
                .AddDefaultTokenProviders();

            }



            services.AddAuthorization(options => {
                options.AddPolicy("TestPolicy", policy => policy.RequireUserName("HappyUser"));
                options.AddPolicy("AtLeast18", policy => policy.Requirements.Add(new RequirementMinimumAge(18)));
                options.AddPolicy("IsOwner", policy => policy.RequireUserName("admin@gmail.com"));
            });

            //Application Services
            {

                //Policy Requirements
                services.AddSingleton<IAuthorizationHandler, HandlerRequirementMinAge>();

                services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<MIdentityUser>>();
                services.AddSingleton<WeatherForecastService>();
                services.AddScoped<IEmailSender, SEmailSender>();
                services.AddSingleton<ISFilesPathBuilder, SFilesPathBuilder>();

                //Pages
                services.AddSingleton<ISPagesCasher, SPagesCasher>();
                services.AddScoped<ISPagesModifier, SPagesModifier>();
                services.AddSingleton<ISPageStream, SPageStream>();
                services.AddScoped<ISPages, SPages>();

                services.AddScoped<ISModal, SModal>();
                services.AddScoped<ISFileUpload, SFileUpload>();
                services.AddScoped<ISThingCounter, SThingCounter>();
                services.AddSingleton<ISGroupsView, SGroupsView>();
                services.AddSingleton<ISBlocks, SBlocks>();
                services.AddScoped<ISBlocksAllow, SBlockAllow>();

                services.AddScoped<ISUsersModeration,SUsersModeration>();
                services.AddScoped<ISUsers, SUsers>();
                services.AddScoped<ISPagesRating,SPagesRating>();
                services.AddScoped<ISPagesUrl, SPagesUrl>();
                services.AddScoped<ISUserProfile, SUserProfile>();
                services.AddScoped<ISFileSave, SFileSave>();
                services.AddScoped<ISMusic, SMusic>();
                services.AddScoped<ISRoles, SRoles>();
                services.AddScoped<IEmailSender, SEmailSender>();
                services.AddSingleton<SEmailHtmlMessagesReader>();
                services.AddSingleton<SURL>();
                services.AddSingleton<ISConfiguration, SConfiguration>();
                services.AddScoped<SBrowser>();
                
            }

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserManager<MIdentityUser> userManager, RoleManager<MIdentityRole> roleManager
            ,ApplicationDbContext dbContext,ISUserProfile sUserProfile,IOptions<MRootAccountSettings> rootAccount)
        {
            UserInitializer.InitializeAsync(dbContext, userManager, roleManager, sUserProfile, rootAccount.Value).Wait();

            //Localization
            {
                var supportedCultures = new[] { "en", "ru" };
                var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[1])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures);
                app.UseRequestLocalization(localizationOptions);
            }

            //app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }
            app.UseHttpsRedirection();

            int staticFilesCacheMaxAge = Configuration.GetSection("cache-time")
                .GetValue<int>("StaticFilesCacheMaxAge");

            //app.UseStaticFiles(
            //    new StaticFileOptions
            //    {
            //        OnPrepareResponse = ctx =>
            //        {
            //            ctx.Context.Response.Headers.Append(new KeyValuePair<string, StringValues>
            //                (HeaderNames.CacheControl, new StringValues($"public, max-age={staticFilesCacheMaxAge}")));
            //        }
            //    }
            //);
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            
        }
    }
}
