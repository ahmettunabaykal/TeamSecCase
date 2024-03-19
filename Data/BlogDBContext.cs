using Microsoft.EntityFrameworkCore;

using CaseTeamSec.Models;

namespace CaseTeamSec.Data
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Writer> Writers { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Additional configuration if needed
        }
    }
}
