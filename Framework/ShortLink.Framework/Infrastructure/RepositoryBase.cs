using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using ShortLink.Framework.Domain;

namespace ShortLink.Framework.Infrastructure;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : DomainBase
{
    private readonly DbContext _context;

    public RepositoryBase(DbContext context)
    {
        _context = context;
    }

    public TEntity GetBy(long id)
    {
        return _context.Find<TEntity>(id);
    }

    public void Add(TEntity entity)
    {
        _context.Add(entity);
    }

    public void Dispose()
    {
        _context?.Dispose();
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }
}