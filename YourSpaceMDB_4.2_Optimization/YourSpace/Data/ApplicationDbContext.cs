using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourSpace.Areas.Identity;
using YourSpace.Modules.Music;
using YourSpace.Modules.Pages.Page;
using YourSpace.Modules.Pages.Page.Models;
using YourSpace.Modules.Pages.Page.Services;
using YourSpace.Modules.ThingCounter;

namespace YourSpace.Data
{
    public class ApplicationDbContext : IdentityDbContext<MIdentityUser,MIdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<MUserProfile> UserProfiles { get; set; }
        public DbSet<MPageInfo> PagesInfo { get; set; }
        public DbSet<MPageBinary> PagesData { get; set; }
        public DbSet<MUrlCompare> PagesUrlToId { get; set; }

        //Marks
        public DbSet<MCounterNote> Subscribe { get; set; }
        public DbSet<MCounterNote> Like { get; set; }

        //Music
        public DbSet<MMusic> Music { get; set; }
    }
}
