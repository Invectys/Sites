using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lottery.Models;
using Lottery.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lottery.Models
{
    public class LotteryContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<OtherUserInformationModel> UsersInfo { get; set; }

        public LotteryContext(DbContextOptions<LotteryContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<ApplicationUser>().ToTable("Users");

            //Enable-Migrations
            //AutomaticMigrationsEnabled на true.
            //update-Database

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
