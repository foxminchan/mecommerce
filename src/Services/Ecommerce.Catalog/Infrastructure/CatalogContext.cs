using Ecommerce.Catalog.Domain.BrandAggregate;
using Ecommerce.Catalog.Domain.CategoryAggregate;
using Ecommerce.Catalog.Domain.ProductAggregate;
using Ecommerce.Catalog.Domain.ProductAttributeAggregate;
using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;
using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Infrastructure;

public sealed class CatalogContext(DbContextOptions<CatalogContext> options) : DbContext(options)
{
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<ProductRelated> ProductRelateds => Set<ProductRelated>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
    public DbSet<Variant> Variants => Set<Variant>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    public DbSet<ProductAttribute> ProductAttributes => Set<ProductAttribute>();
    public DbSet<ProductAttributeCombination> ProductAttributeCombinations =>
        Set<ProductAttributeCombination>();
    public DbSet<ProductAttributeGroup> ProductAttributeGroups => Set<ProductAttributeGroup>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
        modelBuilder.HasPostgresExtension(UniqueType.Extension);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
    }
}
