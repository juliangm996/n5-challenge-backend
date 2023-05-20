namespace N5.Challenge.Api.Infraestructure
{
    public interface IUnitOfWork
    {
        void Commit();
        IRepository<T> GetRepository<T>() where T : class;
    }
}