using Models;

namespace UOW.Repositories
{
    public interface IBlogCategoryRepository
    {
        Task<BlogCategory?> GetByIdAsync(Guid id);
        Task<IEnumerable<BlogCategory>> GetAllAsync();
        Task AddAsync(BlogCategory category);
        Task UpdateAsync(BlogCategory category);
        Task DeleteAsync(Guid id);
    }

}
