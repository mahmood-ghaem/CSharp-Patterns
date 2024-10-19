using DataAccess;
using DataMapper.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataMapper.Repositories
{
    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        private readonly BlogDbContext _context;

        public BlogCategoryRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<BlogCategoryDto?> GetByIdAsync(int id)
        {
            var category = await _context.BlogCategories.FindAsync(id);
            if (category == null)
                return null;

            return new BlogCategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<IEnumerable<BlogCategoryDto>> GetAllAsync()
        {
            return await _context.BlogCategories.Select(c => new BlogCategoryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();
        }

        public async Task AddAsync(BlogCategoryDto categoryDto)
        {
            var category = new BlogCategory
            {
                Name = categoryDto.Name
            };
            await _context.BlogCategories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BlogCategoryDto categoryDto)
        {
            var category = await _context.BlogCategories.FindAsync(categoryDto.Id);
            if (category != null)
            {
                category.Name = categoryDto.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.BlogCategories.FindAsync(id);
            if (category != null)
            {
                _context.BlogCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }

}
