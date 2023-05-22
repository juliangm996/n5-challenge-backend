namespace N5.Challenge.Api.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository Repository();
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}