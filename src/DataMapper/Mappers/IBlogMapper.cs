using DataMapper.DataTransferObjects;
using Models;

namespace DataMapper.Mappers
{
    public interface IBlogMapper
    {
        Blog MapToDomain(BlogDto blogDto);
        BlogDto MapToDto(Blog blog);
    }

}
