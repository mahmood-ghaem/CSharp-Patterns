using CQRS.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace CQRS.Handlers
{
    public class GetBlogByIdQueryHandler
    {
        private readonly BlogDbContext _context;

        public GetBlogByIdQueryHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<Blog?> Handle(GetBlogByIdQuery query)
        {
            if (_context == null)
                throw new InvalidOperationException("Database context is not initialized.");

            var blog = await _context.Blogs
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == query.Id);

            return blog ?? throw new KeyNotFoundException($"Blog with ID {query.Id} not found.");
        }
    }

}
