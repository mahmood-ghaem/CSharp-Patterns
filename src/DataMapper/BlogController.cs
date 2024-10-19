using Models;

namespace DataMapper
{
    public class BlogController
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task CreateBlog(string title, string content, int categoryId)
        {
            var blog = new Blog
            {
                Title = title,
                Content = content,
                CategoryId = categoryId
            };

            await _blogService.AddBlogAsync(blog);
        }

        public async Task UpdateBlog(int id, string title, string content, int categoryId)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);
            if (blog != null)
            {
                blog.Title = title;
                blog.Content = content;
                blog.CategoryId = categoryId;
                await _blogService.UpdateBlogAsync(blog);
            }
        }

        public async Task DeleteBlog(int id)
        {
            await _blogService.DeleteBlogAsync(id);
        }

        public async Task<Blog> GetBlogById(int id)
        {
            return await _blogService.GetBlogByIdAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            return await _blogService.GetAllBlogsAsync();
        }

        public async Task CreateBlogCategory(string name)
        {
            var category = new BlogCategory { Name = name };
            await _blogService.AddBlogCategoryAsync(category);
        }

        public async Task UpdateBlogCategory(int id, string name)
        {
            var category = await _blogService.GetBlogCategoryByIdAsync(id);
            if (category != null)
            {
                category.Name = name;
                await _blogService.UpdateBlogCategoryAsync(category);
            }
        }

        public async Task DeleteBlogCategory(int id)
        {
            await _blogService.DeleteBlogCategoryAsync(id);
        }

        public async Task<BlogCategory> GetBlogCategoryById(int id)
        {
            return await _blogService.GetBlogCategoryByIdAsync(id);
        }

        public async Task<IEnumerable<BlogCategory>> GetAllBlogCategories()
        {
            return await _blogService.GetAllBlogCategoriesAsync();
        }
    }

}
