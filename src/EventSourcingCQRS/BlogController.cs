using EventSourcingCQRS.Models;
using Models;

namespace EventSourcingCQRS
{
    public class BlogController 
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        public Blog GetById(Guid id)
        {
            return _blogService.GetById(id);
        }

        public IEnumerable<Blog> GetAll()
        {
            return _blogService.GetAll();
        }

        public void Create(CreateBlogCommand command)
        {
            _blogService.Create(command);
        }

        public void Update(Guid id, CreateBlogCommand command)
        {
            _blogService.Update(id, command);
        }

        public void Delete(Guid id)
        {
            _blogService.Delete(id);
        }
    }

}
