using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShortLink.Application.UrlSchemaService.Query;
using ShortLink.Domain.UrlSchemaAgg;
using ShortLink.Framework.Infrastructure;
using ShortLink.Infrastructure.EfCore;
using ShortLink.Infrastructure.EfCore.Repositories;

namespace ShortLink.Infrastructure.Core;
public class Bootstrapper
{
    public static void Config(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddTransient<IUnitOfWork, UnitOfWorkEf>();

        #region Repositories

        services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        services.AddTransient<IUrlSchemaRepository, UrlSchemaRepository>();

        #endregion Repositories

        services.AddOptions();

        services.AddMediatR(typeof(UrlSchemaQueryHandler));


    }
}
