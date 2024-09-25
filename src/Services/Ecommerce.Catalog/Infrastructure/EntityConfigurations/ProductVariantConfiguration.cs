using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Infrastructure.EntityConfigurations;

internal sealed class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Sku).HasMaxLength(DataSchemaLength.Medium).IsRequired();

        builder.OwnsOne(
            x => x.Price,
            price =>
            {
                price.Property(p => p.OriginalPrice).HasPrecision(18, 2).IsRequired();

                price.Property(p => p.DiscountPrice).HasPrecision(18, 2);
            }
        );

        builder
            .HasMany(x => x.Combinations)
            .WithOne(x => x.ProductVariant)
            .HasForeignKey(x => x.ProductVariantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.Sku).IsUnique();

        builder.HasIndex(x => x.DisplayOrder).IsUnique();

        builder.Navigation(x => x.Combinations).AutoInclude();
    }
}
