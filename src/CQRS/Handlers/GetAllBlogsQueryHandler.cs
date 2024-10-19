using CQRS.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace CQRS.Handlers
{
    public class GetAllBlogsQueryHandler
    {
        private readonly BlogDbContext _context;

        public GetAllBlogsQueryHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> Handle(GetAllBlogsQuery query)
        {
            return await _context.Blogs.Include(b => b.Category).ToListAsync();
        }
    }

}
