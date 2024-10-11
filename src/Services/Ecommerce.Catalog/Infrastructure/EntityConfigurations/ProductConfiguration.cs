using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Infrastructure.EntityConfigurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasDefaultValueSql(UniqueType.Algorithm).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).HasMaxLength(DataSchemaLength.ExtraLarge).IsRequired();

        builder.Property(x => x.ShortDescription).HasMaxLength(DataSchemaLength.SuperLarge);

        builder.Property(x => x.Description).HasMaxLength(DataSchemaLength.Max);

        builder.Property(x => x.Specification).HasMaxLength(DataSchemaLength.UltraMax);

        builder.Property(x => x.Slug).HasMaxLength(DataSchemaLength.ExtraLarge).IsRequired();

        builder.Property(x => x.MetaTitle).HasMaxLength(DataSchemaLength.ExtraLarge);

        builder.Property(x => x.MetaDescription).HasMaxLength(DataSchemaLength.ExtraLarge);

        builder.Property(x => x.MetaKeywords).HasMaxLength(DataSchemaLength.ExtraLarge);

        builder.Property(x => x.Gtin).HasMaxLength(DataSchemaLength.Medium);

        builder.OwnsOne(
            x => x.Price,
            price =>
            {
                price.Property(p => p.OriginalPrice).HasPrecision(18, 2).IsRequired();

                price.Property(p => p.DiscountPrice).HasPrecision(18, 2);
            }
        );

        builder
            .HasGeneratedTsVectorColumn(
                p => p.SearchVector!,
                "english",
                x => new
                {
                    x.Name,
                    x.Description,
                    x.MetaKeywords,
                }
            )
            .HasIndex(p => p.SearchVector)
            .HasMethod("GIN");

        builder.HasIndex(x => x.Slug).IsUnique();

        builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.LastModifiedAt).HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.Version).IsConcurrencyToken();

        builder
            .HasMany(x => x.ProductCategories)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.ProductVariants)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.ProductImages)
            .WithOne()
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.ProductAttributes)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.ProductRelateds)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Brand).AutoInclude();

        builder.Navigation(x => x.ProductCategories).AutoInclude();

        builder.Navigation(x => x.ProductVariants).AutoInclude();

        builder.Navigation(x => x.ProductImages).AutoInclude();

        builder.Navigation(x => x.ProductAttributes).AutoInclude();

        builder.Navigation(x => x.ProductRelateds).AutoInclude();
    }
}
