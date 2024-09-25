using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Infrastructure.EntityConfigurations;

internal sealed class ProductAttributeCombinationConfiguration
    : IEntityTypeConfiguration<ProductAttributeCombination>
{
    public void Configure(EntityTypeBuilder<ProductAttributeCombination> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Value).HasMaxLength(DataSchemaLength.Max).IsRequired();

        builder
            .HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Attribute)
            .WithMany()
            .HasForeignKey(x => x.AttributeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
