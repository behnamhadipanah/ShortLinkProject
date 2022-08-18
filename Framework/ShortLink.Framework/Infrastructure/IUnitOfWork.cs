namespace ShortLink.Framework.Infrastructure;

public interface IUnitOfWork
{
    void BeginTransaction();
    bool CommitTransaction();
    void Rollback();
}