using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShortLink.Domain.UrlSchemaAgg;

namespace ShortLink.Infrastructure.EfCore.Mapping
{
    public class UrlSchemaMapping:IEntityTypeConfiguration<UrlSchema>
    {
        public void Configure(EntityTypeBuilder<UrlSchema> builder)
        {
            builder.ToTable("UrlSchemas", "dbo");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ShortUrl).IsUnique();
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.LongUrl).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.ShortUrl).HasMaxLength(255).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();

        }
    }
}
