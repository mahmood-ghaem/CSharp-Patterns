using CQRS.Handlers;
using CQRS.Models;
using Models;

namespace CQRS
{
    public class BlogService
    {
        private readonly CreateBlogCommandHandler _createBlogHandler;
        private readonly UpdateBlogCommandHandler _updateBlogHandler;
        private readonly DeleteBlogCommandHandler _deleteBlogHandler;
        private readonly GetBlogByIdQueryHandler _getBlogByIdHandler;
        private readonly GetAllBlogsQueryHandler _getAllBlogsHandler;

        public BlogService(
            CreateBlogCommandHandler createBlogHandler,
            UpdateBlogCommandHandler updateBlogHandler,
            DeleteBlogCommandHandler deleteBlogHandler,
            GetBlogByIdQueryHandler getBlogByIdHandler,
            GetAllBlogsQueryHandler getAllBlogsHandler)
        {
            _createBlogHandler = createBlogHandler;
            _updateBlogHandler = updateBlogHandler;
            _deleteBlogHandler = deleteBlogHandler;
            _getBlogByIdHandler = getBlogByIdHandler;
            _getAllBlogsHandler = getAllBlogsHandler;
        }

        public async Task CreateBlog(string title, string content, Guid categoryId)
        {
            var command = new CreateBlogCommand
            {
                Title = title,
                Content = content,
                CategoryId = categoryId
            };

            await _createBlogHandler.Handle(command);
        }

        public async Task UpdateBlog(Guid id, string title, string content, Guid categoryId)
        {
            var command = new UpdateBlogCommand
            {
                Id = id,
                Title = title,
                Content = content,
                CategoryId = categoryId
            };

            await _updateBlogHandler.Handle(command);
        }

        public async Task DeleteBlog(Guid id)
        {
            var command = new DeleteBlogCommand { Id = id };
            await _deleteBlogHandler.Handle(command);
        }

        public async Task<Blog> GetBlogById(Guid id)
        {
            var query = new GetBlogByIdQuery { Id = id };
            return await _getBlogByIdHandler.Handle(query);
        }

        public async Task<List<Blog>> GetAllBlogs()
        {
            var query = new GetAllBlogsQuery();
            return await _getAllBlogsHandler.Handle(query);
        }
    }
}
