using DataMapper.DataTransferObjects;

namespace DataMapper.Repositories
{
    public interface IBlogRepository
    {
        Task<BlogDto?> GetByIdAsync(int id);
        Task<IEnumerable<BlogDto>> GetAllAsync();
        Task AddAsync(BlogDto blogDto);
        Task UpdateAsync(BlogDto blogDto);
        Task DeleteAsync(int id);
    }

}
