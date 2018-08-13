using Instagraph.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagraph.Data
{
    public class InstagraphContext : DbContext
    {
        public InstagraphContext() { }

        public InstagraphContext(DbContextOptions options)
            :base(options) { }
        
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFollower> UsersFollowers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFollower>().HasKey(uf => new { uf.UserId, uf.FollowerId });

            modelBuilder.Entity<User>().HasMany(u => u.UsersFollowing).WithOne(uf => uf.Follower).HasForeignKey(uf => uf.FollowerId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasMany(u => u.Followers).WithOne(uf => uf.User).HasForeignKey(uf => uf.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasMany(p => p.Posts).WithOne(u => u.User).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasMany(c => c.Comments).WithOne(u => u.User).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasIndex(u => u.Username);
        }
    }
}
