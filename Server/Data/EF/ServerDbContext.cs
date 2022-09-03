using Microsoft.EntityFrameworkCore;
using Server.Data.Configuration;
using Server.Extension;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data.EF
{
    public class ServerDbContext : DbContext
    {
        public ServerDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentsConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new PostsConfiguration());
            modelBuilder.ApplyConfiguration(new FriendsConfiguration());
            modelBuilder.ApplyConfiguration(new MessagesConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationsConfiguration());

            modelBuilder.Seed();
        }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Notifications> Notifications { get; set; }

    }
}
