using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Infrastructure.EntityConfigurations;

internal sealed class ProductVariantCombinationConfiguration
    : IEntityTypeConfiguration<ProductVariantCombination>
{
    public void Configure(EntityTypeBuilder<ProductVariantCombination> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder
            .HasOne(x => x.Variant)
            .WithMany()
            .HasForeignKey(x => x.VariantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
