using ShortLink.Application.Contract.UrlSchema;
using ShortLink.Framework.Infrastructure;

namespace ShortLink.Domain.UrlSchemaAgg;

public interface IUrlSchemaRepository:IRepositoryBase<UrlSchema>
{
    UrlSchemaViewModel? GetUrlSchema(string shortUrl);
}