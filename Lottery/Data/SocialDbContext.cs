using Lottery.Models.Social;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Data
{
    public class SocialDbContext : DbContext
    {

        public DbSet<LikeAction> Likes { get; set; }
        public DbSet<LikeList> ObjectLikes { get; set; }

        public SocialDbContext(DbContextOptions<SocialDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
