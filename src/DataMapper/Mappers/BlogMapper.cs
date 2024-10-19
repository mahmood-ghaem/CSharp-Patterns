using DataMapper.DataTransferObjects;
using Models;

namespace DataMapper.Mappers
{
    public class BlogMapper : IBlogMapper
    {
        public Blog MapToDomain(BlogDto blogDto)
        {
            return new Blog
            {
                Id = blogDto.Id,
                Title = blogDto.Title,
                Content = blogDto.Content,
                CategoryId = blogDto.CategoryId
            };
        }

        public BlogDto MapToDto(Blog blog)
        {
            return new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                CategoryId = blog.CategoryId
            };
        }
    }

}
