using Microsoft.EntityFrameworkCore;

namespace ActiveRecord
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
    }

}
