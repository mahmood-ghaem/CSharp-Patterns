namespace UOW.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository Blogs { get; }
        IBlogCategoryRepository BlogCategories { get; }
        Task<int> CompleteAsync();
    }

}
