using Microsoft.EntityFrameworkCore;

namespace ActiveRecord
{
    public class BlogCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        private static BlogDbContext _context;

        public BlogCategory(DbContextOptions<BlogDbContext> options)
        {
            _context = new BlogDbContext(options);
        }

        public static async Task<BlogCategory> GetByIdAsync(Guid id)
        {
            return await _context.BlogCategories.FindAsync(id);
        }

        public static async Task<IEnumerable<BlogCategory>> GetAllAsync()
        {
            return await _context.BlogCategories.ToListAsync();
        }

        public async Task AddAsync()
        {
            await _context.BlogCategories.AddAsync(this);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync()
        {
            _context.BlogCategories.Update(this);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync()
        {
            _context.BlogCategories.Remove(this);
            await _context.SaveChangesAsync();
        }
    }


}
