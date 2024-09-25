using Ecommerce.Catalog.Domain.BrandAggregate;

namespace Ecommerce.Catalog.Infrastructure.EntityConfigurations;

internal sealed class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).HasMaxLength(DataSchemaLength.ExtraLarge).IsRequired();

        builder.Property(x => x.Description).HasMaxLength(DataSchemaLength.Max);

        builder.Property(x => x.Slug).HasMaxLength(DataSchemaLength.Medium).IsRequired();

        builder.Property(x => x.MetaTitle).HasMaxLength(DataSchemaLength.ExtraLarge);

        builder.Property(x => x.MetaDescription).HasMaxLength(DataSchemaLength.ExtraLarge);

        builder.Property(x => x.MetaKeywords).HasMaxLength(DataSchemaLength.ExtraLarge);

        builder.HasIndex(x => x.Slug).IsUnique();

        builder.HasIndex(x => x.DisplayOrder).IsUnique();

        builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.LastModifiedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.Version).IsConcurrencyToken();

        builder
            .HasMany(x => x.Products)
            .WithOne(x => x.Brand)
            .HasForeignKey(x => x.BrandId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
