using EventSourcingCQRS.Events;
using EventSourcingCQRS.Models;
using Models;

namespace EventSourcingCQRS
{
    public class BlogService
    {
        private readonly EventStore _eventStore;

        public BlogService(EventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public Blog? GetById(Guid id)
        {
            var events = _eventStore.GetAllEvents().OfType<BlogCreatedEvent>().Where(e => e.Id == id);
            var blogEvent = events.FirstOrDefault();
            if (blogEvent == null) return null;

            return new Blog
            {
                Id = blogEvent.Id,
                Title = blogEvent.Title,
                Content = blogEvent.Content,
                CategoryId = blogEvent.CategoryId
            };
        }

        public IEnumerable<Blog> GetAll()
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

        public void Create(CreateBlogCommand command)
        {
            var blogCreatedEvent = new BlogCreatedEvent
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                Title = command.Title,
                Content = command.Content,
                CategoryId = command.CategoryId
            };

            _eventStore.Save(blogCreatedEvent);
        }

        public void Update(Guid id, CreateBlogCommand command)
        {
            var blog = GetById(id);
            if (blog == null) return;

            var blogUpdatedEvent = new BlogCreatedEvent
            {
                Id = id,
                Timestamp = DateTime.UtcNow,
                Title = command.Title,
                Content = command.Content,
                CategoryId = command.CategoryId
            };

            _eventStore.Save(blogUpdatedEvent);
        }

        public void Delete(Guid id)
        {
            var blog = GetById(id);
            if (blog == null) return;

            var blogDeletedEvent = new BlogCreatedEvent
            {
                Id = id,
                Timestamp = DateTime.UtcNow,
                Title = blog.Title,
                Content = blog.Content,
                CategoryId = blog.CategoryId
            };

            _eventStore.Save(blogDeletedEvent);
        }
    }

}
