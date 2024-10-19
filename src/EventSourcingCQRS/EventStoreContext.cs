using EventSourcingCQRS.Events;
using Microsoft.EntityFrameworkCore;

namespace EventSourcingCQRS
{
    public class EventStoreContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public EventStoreContext(DbContextOptions<EventStoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasKey(e => e.Id);
            modelBuilder.Entity<BlogCreatedEvent>().HasBaseType<Event>();
            modelBuilder.Entity<BlogCategoryCreatedEvent>().HasBaseType<Event>();
        }
    }

}
