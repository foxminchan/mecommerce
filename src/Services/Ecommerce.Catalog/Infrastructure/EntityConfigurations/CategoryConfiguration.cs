using Ecommerce.Catalog.Domain.CategoryAggregate;

namespace Ecommerce.Catalog.Infrastructure.EntityConfigurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
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
            .HasOne(x => x.Parent)
            .WithMany(x => x.Children)
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(x => x.ProductCategories)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
