using ShortLink.Framework.Domain;

namespace ShortLink.Framework.Infrastructure;

public interface IRepositoryBase<TEntity> where TEntity : DomainBase
{
    TEntity GetBy(long id);
    void Add(TEntity entity);
    void Dispose();
    bool SaveChanges();

}