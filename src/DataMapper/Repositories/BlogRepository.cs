using DataAccess;
using DataMapper.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataMapper.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;

        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<BlogDto?> GetByIdAsync(Guid id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
                return null;

            return new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                CategoryId = blog.CategoryId
            };
        }

        public async Task<IEnumerable<BlogDto>> GetAllAsync()
        {
            return await _context.Blogs.Select(b => new BlogDto
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                CategoryId = b.CategoryId
            }).ToListAsync();
        }

        public async Task AddAsync(BlogDto blogDto)
        {
            var blog = new Blog
            {
                Title = blogDto.Title,
                Content = blogDto.Content,
                CategoryId = blogDto.CategoryId
            };
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BlogDto blogDto)
        {
            var blog = await _context.Blogs.FindAsync(blogDto.Id);
            if (blog != null)
            {
                blog.Title = blogDto.Title;
                blog.Content = blogDto.Content;
                blog.CategoryId = blogDto.CategoryId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
            }
        }
    }

}
