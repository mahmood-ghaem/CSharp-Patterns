using DataMapper.DataTransferObjects;

namespace DataMapper.Repositories
{
    public interface IBlogCategoryRepository
    {
        Task<BlogCategoryDto?> GetByIdAsync(int id);
        Task<IEnumerable<BlogCategoryDto>> GetAllAsync();
        Task AddAsync(BlogCategoryDto categoryDto);
        Task UpdateAsync(BlogCategoryDto categoryDto);
        Task DeleteAsync(int id);
    }

}
