using DataMapper.DataTransferObjects;

namespace DataMapper.Repositories
{
    public interface IBlogCategoryRepository
    {
        Task<BlogCategoryDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<BlogCategoryDto>> GetAllAsync();
        Task AddAsync(BlogCategoryDto categoryDto);
        Task UpdateAsync(BlogCategoryDto categoryDto);
        Task DeleteAsync(Guid id);
    }

}
