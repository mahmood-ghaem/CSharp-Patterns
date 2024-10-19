using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace UOW.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;

        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            var blog = await _context.Blogs.Include(b => b.Category).FirstOrDefaultAsync(b => b.Id == id);
            return blog ?? throw new KeyNotFoundException($"Blog with ID {id} not found.");
        }


        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _context.Blogs.Include(b => b.Category).ToListAsync();
        }

        public async Task AddAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
        }

        public async Task UpdateAsync(Blog blog)
        {
            _context.Blogs.Update(blog);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
            }
        }
    }

}
