using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Infrastructure.EntityConfigurations;

internal sealed class ProductRelatedConfiguration : IEntityTypeConfiguration<ProductRelated>
{
    public void Configure(EntityTypeBuilder<ProductRelated> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder
            .HasOne(x => x.RelatedProduct)
            .WithMany()
            .HasForeignKey(x => x.RelatedProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Product).AutoInclude();
    }
}
