using System.Globalization;
using ShortLink.Application.Contract.UrlSchema;
using ShortLink.Domain.UrlSchemaAgg;
using ShortLink.Framework.Infrastructure;

namespace ShortLink.Infrastructure.EfCore.Repositories;

public class UrlSchemaRepository:RepositoryBase<UrlSchema>, IUrlSchemaRepository
{
    private  readonly AppDbContext _context;
    public UrlSchemaRepository(AppDbContext context):base(context)
    {
        _context=context;
    }

    public UrlSchemaViewModel? GetUrlSchema(string shortUrl)
    {
        return _context.UrlSchemas.Where(x => x.ShortUrl == shortUrl).Select(x => new UrlSchemaViewModel()
        {
            Id = x.Id,
            ShortUrl = x.ShortUrl,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            LongUrl = x.LongUrl,
        }).SingleOrDefault();
    }
}