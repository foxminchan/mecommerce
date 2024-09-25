using Ecommerce.Media.Domain;

namespace Ecommerce.Media.Infrastructure.Data.EntityConfigurations;

internal sealed class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasDefaultValueSql(UniqueType.Algorithm).ValueGeneratedOnAdd();

        builder.Property(x => x.FileName).HasMaxLength(DataSchemaLength.Medium).IsRequired();

        builder.Property(x => x.Caption).HasMaxLength(DataSchemaLength.Max).IsRequired();

        builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.LastModifiedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.Version).IsConcurrencyToken();
    }
}
