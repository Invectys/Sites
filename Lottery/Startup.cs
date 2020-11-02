using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lottery.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lottery.Hubs;
using Lottery.Models;
using Lottery.Games;
using Lottery.Interfaces;
using System.Text;
using Microsoft.Extensions.Options;
using Lottery.Other;
using Lottery.Portal.News;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Lottery.Portal.Social;
using Lottery.Routes.Constraints;
using Lottery.Models.OptionsModels;

namespace Lottery
{
    public class Startup
    {
        private IServiceCollection _services;
        


        public Startup(IConfiguration configuration,IHostingEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("Lottery.json");
            LotteryConf = builder.Build();
        }

        public IConfiguration Configuration { get; }
        public IConfiguration LotteryConf { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;

            

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("UsersDB")));
            services.AddDbContext<SocialDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("SocialDB")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                
            });

            



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                            .AddViewOptions(options=>
                            {
                                options.HtmlHelperOptions.ClientValidationEnabled = true;
                            });

            services.Configure<HtmlHelperOptions>(o => o.ClientValidationEnabled = true);

            //services.AddRouting();

            services.AddHttpClient();

            services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
            });

            
            services.AddSingleton<IHubSender, HubSender>();
            services.AddSingleton<GamesStore>();
            services.AddSingleton<FakeControl>();
            services.AddScoped<IGamesControl, GamesControl>();
            services.AddTransient<EmailService>();
            services.AddTransient<ArticleService>();
            services.AddTransient<GoogleCaptchaService>();
            services.AddScoped<FileControl>();
            services.AddScoped<PageService>();

            services.Configure<MainOptions>(Configuration);
            services.Configure<GoogleCaptchaSettings>(Configuration);
            services.Configure<AuthorizationSettings>(Configuration);
            services.Configure<LotteryOptions>(LotteryConf);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //var Router = new RouteHandler(Handle);
            //var routeBuilder = new RouteBuilder(app, Router);
            //routeBuilder.MapRoute("start", "{News}/{Index}");
            //app.UseRouter(routeBuilder.Build());



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseDatabaseErrorPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();

            }



            
            app.UseStatusCodePagesWithReExecute("/error/{0}/index.html");
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            

            app.UseMvc(routes =>
            {

                
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute("Pages","{id}/{PageName}", new { action = "person" ,controller = "PersonalPages"});




            });

            app.UseSignalR(routes =>
            {
                routes.MapHub<GameHub>("/gameHub");
            });


            



        }
    }
}
