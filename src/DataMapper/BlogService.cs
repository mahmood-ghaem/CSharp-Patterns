using DataMapper.Mappers;
using DataMapper.Repositories;
using Models;

namespace DataMapper
{
    public class BlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly IBlogMapper _blogMapper;
        private readonly IBlogCategoryMapper _blogCategoryMapper;

        public BlogService(
            IBlogRepository blogRepository,
            IBlogCategoryRepository blogCategoryRepository,
            IBlogMapper blogMapper,
            IBlogCategoryMapper blogCategoryMapper)
        {
            _blogRepository = blogRepository;
            _blogCategoryRepository = blogCategoryRepository;
            _blogMapper = blogMapper;
            _blogCategoryMapper = blogCategoryMapper;
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            var blogDto = await _blogRepository.GetByIdAsync(id);
            return _blogMapper.MapToDomain(blogDto);
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
            var blogDtos = await _blogRepository.GetAllAsync();
            return blogDtos.Select(_blogMapper.MapToDomain);
        }

        public async Task AddBlogAsync(Blog blog)
        {
            var blogDto = _blogMapper.MapToDto(blog);
            await _blogRepository.AddAsync(blogDto);
        }

        public async Task UpdateBlogAsync(Blog blog)
        {
            var blogDto = _blogMapper.MapToDto(blog);
            await _blogRepository.UpdateAsync(blogDto);
        }

        public async Task DeleteBlogAsync(int id)
        {
            await _blogRepository.DeleteAsync(id);
        }

        public async Task<BlogCategory> GetBlogCategoryByIdAsync(int id)
        {
            var categoryDto = await _blogCategoryRepository.GetByIdAsync(id);
            return _blogCategoryMapper.MapToDomain(categoryDto);
        }

        public async Task<IEnumerable<BlogCategory>> GetAllBlogCategoriesAsync()
        {
            var categoryDtos = await _blogCategoryRepository.GetAllAsync();
            return categoryDtos.Select(_blogCategoryMapper.MapToDomain);
        }

        public async Task AddBlogCategoryAsync(BlogCategory category)
        {
            var categoryDto = _blogCategoryMapper.MapToDto(category);
            await _blogCategoryRepository.AddAsync(categoryDto);
        }

        public async Task UpdateBlogCategoryAsync(BlogCategory category)
        {
            var categoryDto = _blogCategoryMapper.MapToDto(category);
            await _blogCategoryRepository.UpdateAsync(categoryDto);
        }

        public async Task DeleteBlogCategoryAsync(int id)
        {
            await _blogCategoryRepository.DeleteAsync(id);
        }
    }

}
