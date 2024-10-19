using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace UOW.Repositories
{
    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        private readonly BlogDbContext _context;

        public BlogCategoryRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<BlogCategory?> GetByIdAsync(int id)
        {
            return await _context.BlogCategories.FindAsync(id);
        }

        public async Task<IEnumerable<BlogCategory>> GetAllAsync()
        {
            return await _context.BlogCategories.ToListAsync();
        }

        public async Task AddAsync(BlogCategory category)
        {
            await _context.BlogCategories.AddAsync(category);
        }

        public async Task UpdateAsync(BlogCategory category)
        {
            _context.BlogCategories.Update(category);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.BlogCategories.FindAsync(id);
            if (category != null)
            {
                _context.BlogCategories.Remove(category);
            }
        }
    }

}
