using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ShortLink.Domain.UrlSchemaAgg;
using ShortLink.Infrastructure.EfCore.Mapping;

namespace ShortLink.Infrastructure.EfCore;


public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

    public AppDbContext(){}

    #region DbSet

    public DbSet<UrlSchema> UrlSchemas { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(UrlSchemaMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(modelBuilder);
    }
}
