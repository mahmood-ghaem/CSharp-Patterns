using DataMapper.DataTransferObjects;

namespace DataMapper.Repositories
{
    public interface IBlogRepository
    {
        Task<BlogDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<BlogDto>> GetAllAsync();
        Task AddAsync(BlogDto blogDto);
        Task UpdateAsync(BlogDto blogDto);
        Task DeleteAsync(Guid id);
    }

}
