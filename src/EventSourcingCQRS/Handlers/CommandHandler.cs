using EventSourcingCQRS.Events;
using EventSourcingCQRS.Models;

namespace EventSourcingCQRS.Handlers
{
    public class CommandHandler
    {
        private readonly EventStore _eventStore;

        public CommandHandler(EventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void Handle(CreateBlogCommand command)
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

        public void Handle(CreateBlogCategoryCommand command)
        {
            var blogCategoryCreatedEvent = new BlogCategoryCreatedEvent
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                Name = command.Name
            };

            _eventStore.Save(blogCategoryCreatedEvent);
        }
    }

}
