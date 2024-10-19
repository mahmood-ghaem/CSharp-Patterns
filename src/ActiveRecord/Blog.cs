using Microsoft.EntityFrameworkCore;

namespace ActiveRecord
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Guid CategoryId { get; set; }
        public BlogCategory? Category { get; set; }

        private static BlogDbContext _context;

        public Blog(DbContextOptions<BlogDbContext> options)
        {
            _context = new BlogDbContext(options);
        }

        public static async Task<Blog> GetByIdAsync(Guid id)
        {
            return await _context.Blogs.Include(b => b.Category).FirstOrDefaultAsync(b => b.Id == id);
        }

        public static async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _context.Blogs.Include(b => b.Category).ToListAsync();
        }

        public async Task AddAsync()
        {
            await _context.Blogs.AddAsync(this);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync()
        {
            _context.Blogs.Update(this);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync()
        {
            _context.Blogs.Remove(this);
            await _context.SaveChangesAsync();
        }
    }


}
