using CQRS.Models;

namespace CQRS.Handlers
{
    public class DeleteBlogCommandHandler
    {
        private readonly BlogDbContext _context;

        public DeleteBlogCommandHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteBlogCommand command)
        {
            var blog = await _context.Blogs.FindAsync(command.Id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
            }
        }
    }

}
