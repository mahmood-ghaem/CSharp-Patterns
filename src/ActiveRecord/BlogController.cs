using Microsoft.EntityFrameworkCore;

namespace ActiveRecord
{
    public class BlogController
    {
        private readonly DbContextOptions<BlogDbContext> _options;

        public BlogController(DbContextOptions<BlogDbContext> options)
        {
            _options = options;
        }

        public async Task CreateBlog(string title, string content, int categoryId)
        {
            var blog = new Blog(_options)
            {
                Title = title,
                Content = content,
                CategoryId = categoryId
            };

            await blog.AddAsync();
        }

        public async Task UpdateBlog(int id, string title, string content, int categoryId)
        {
            var blog = new Blog(_options);
            blog = await Blog.GetByIdAsync(id);
            if (blog != null)
            {
                blog.Title = title;
                blog.Content = content;
                blog.CategoryId = categoryId;
                await blog.UpdateAsync();
            }
        }

        public async Task DeleteBlog(int id)
        {
            var blog = new Blog(_options);
            blog = await Blog.GetByIdAsync(id);
            if (blog != null)
            {
                await blog.DeleteAsync();
            }
        }

        public async Task<Blog> GetBlogById(int id)
        {
            var blog = new Blog(_options);
            return await Blog.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            var blog = new Blog(_options);
            return await Blog.GetAllAsync();
        }

        public async Task CreateBlogCategory(string name)
        {
            var category = new BlogCategory(_options) { Name = name };
            await category.AddAsync();
        }

        public async Task UpdateBlogCategory(int id, string name)
        {
            var category = new BlogCategory(_options);
            category = await BlogCategory.GetByIdAsync(id);
            if (category != null)
            {
                category.Name = name;
                await category.UpdateAsync();
            }
        }

        public async Task DeleteBlogCategory(int id)
        {
            var category = new BlogCategory(_options);
            category = await BlogCategory.GetByIdAsync(id);
            if (category != null)
            {
                await category.DeleteAsync();
            }
        }

        public async Task<BlogCategory> GetBlogCategoryById(int id)
        {
            var category = new BlogCategory(_options);
            return await BlogCategory.GetByIdAsync(id);
        }

        public async Task<IEnumerable<BlogCategory>> GetAllBlogCategories()
        {
            var category = new BlogCategory(_options);
            return await BlogCategory.GetAllAsync();
        }
    }


}
