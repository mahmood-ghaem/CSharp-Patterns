using DataMapper.DataTransferObjects;
using Models;

namespace DataMapper.Mappers
{
    public interface IBlogCategoryMapper
    {
        BlogCategory MapToDomain(BlogCategoryDto categoryDto);
        BlogCategoryDto MapToDto(BlogCategory category);
    }

}
