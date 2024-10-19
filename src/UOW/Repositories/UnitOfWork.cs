namespace UOW.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _context;
        public IBlogRepository Blogs { get; private set; }
        public IBlogCategoryRepository BlogCategories { get; private set; }

        public UnitOfWork(BlogDbContext context, IBlogRepository blogRepository, IBlogCategoryRepository blogCategoryRepository)
        {
            _context = context;
            Blogs = blogRepository;
            BlogCategories = blogCategoryRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
