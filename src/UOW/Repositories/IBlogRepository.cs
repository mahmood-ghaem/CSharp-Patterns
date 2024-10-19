using Models;

namespace UOW.Repositories
{
    public interface IBlogRepository
    {
        Task<Blog?> GetByIdAsync(int id);
        Task<IEnumerable<Blog>> GetAllAsync();
        Task AddAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task DeleteAsync(int id);
    }

}
