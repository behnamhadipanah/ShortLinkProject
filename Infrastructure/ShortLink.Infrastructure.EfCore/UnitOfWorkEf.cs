using ShortLink.Framework.Infrastructure;

namespace ShortLink.Infrastructure.EfCore;

public class UnitOfWorkEf : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWorkEf(AppDbContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        _context.Database.BeginTransaction();
    }

    public bool CommitTransaction()
    {
        var result = _context.SaveChanges();
        _context.Database.CommitTransaction();
        return result > 0;
    }

    public void Rollback()
    {
        _context.Database.RollbackTransaction();
    }
}