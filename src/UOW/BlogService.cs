using Models;
using UOW.Repositories;

namespace UOW
{
    public class BlogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _unitOfWork.Blogs.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
            return await _unitOfWork.Blogs.GetAllAsync();
        }

        public async Task AddBlogAsync(Blog blog)
        {
            await _unitOfWork.Blogs.AddAsync(blog);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateBlogAsync(Blog blog)
        {
            await _unitOfWork.Blogs.UpdateAsync(blog);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteBlogAsync(int id)
        {
            await _unitOfWork.Blogs.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<BlogCategory> GetBlogCategoryByIdAsync(int id)
        {
            return await _unitOfWork.BlogCategories.GetByIdAsync(id);
        }

        public async Task<IEnumerable<BlogCategory>> GetAllBlogCategoriesAsync()
        {
            return await _unitOfWork.BlogCategories.GetAllAsync();
        }

        public async Task AddBlogCategoryAsync(BlogCategory category)
        {
            await _unitOfWork.BlogCategories.AddAsync(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateBlogCategoryAsync(BlogCategory category)
        {
            await _unitOfWork.BlogCategories.UpdateAsync(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteBlogCategoryAsync(int id)
        {
            await _unitOfWork.BlogCategories.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }

}
