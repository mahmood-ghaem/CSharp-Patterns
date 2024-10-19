using EventSourcingCQRS.Events;
using Models;

namespace EventSourcingCQRS.Handlers
{
    public class QueryHandler
    {
        private readonly EventStore _eventStore;

        public QueryHandler(EventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            var events = _eventStore.GetAllEvents().OfType<BlogCreatedEvent>();
            return events.Select(e => new Blog
            {
                Id = e.Id,
                Title = e.Title,
                Content = e.Content,
                CategoryId = e.CategoryId
            });
        }

        public IEnumerable<BlogCategory> GetAllBlogCategories()
        {
            var events = _eventStore.GetAllEvents().OfType<BlogCategoryCreatedEvent>();
            return events.Select(e => new BlogCategory
            {
                Id = e.Id,
                Name = e.Name
            });
        }
    }

}
