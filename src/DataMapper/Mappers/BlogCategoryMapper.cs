using DataMapper.DataTransferObjects;
using Models;

namespace DataMapper.Mappers
{
    public class BlogCategoryMapper : IBlogCategoryMapper
    {
        public BlogCategory MapToDomain(BlogCategoryDto categoryDto)
        {
            return new BlogCategory
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name
            };
        }

        public BlogCategoryDto MapToDto(BlogCategory category)
        {
            return new BlogCategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }

}
