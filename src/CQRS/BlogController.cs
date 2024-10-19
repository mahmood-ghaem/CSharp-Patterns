using Models;

namespace CQRS
{
    public class BlogController
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task CreateBlog(string title, string content, Guid categoryId)
        {
            await _blogService.CreateBlog(title, content, categoryId);
        }

        public async Task UpdateBlog(Guid id, string title, string content, Guid categoryId)
        {
            await _blogService.UpdateBlog(id, title, content, categoryId);
        }

        public async Task DeleteBlog(Guid id)
        {
            await _blogService.DeleteBlog(id);
        }

        public async Task<Blog> GetBlogById(Guid id)
        {
            return await _blogService.GetBlogById(id);
        }

        public async Task<List<Blog>> GetAllBlogs()
        {
            return await _blogService.GetAllBlogs();
        }
    }
}
