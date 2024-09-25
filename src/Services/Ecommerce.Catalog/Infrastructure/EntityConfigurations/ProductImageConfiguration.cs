using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Infrastructure.EntityConfigurations;

internal sealed class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(x => new { x.Id, x.ProductId });

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
}
