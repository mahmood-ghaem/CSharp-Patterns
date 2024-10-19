using Models;

namespace UOW.Repositories
{
    public interface IBlogCategoryRepository
    {
        Task<BlogCategory?> GetByIdAsync(int id);
        Task<IEnumerable<BlogCategory>> GetAllAsync();
        Task AddAsync(BlogCategory category);
        Task UpdateAsync(BlogCategory category);
        Task DeleteAsync(int id);
    }

}
