namespace Ecommerce.Catalog.Domain.ProductAggregate;

public sealed class ProductImage : Entity<long>
{
    public ProductImage() { }

    public ProductImage(Guid imageId)
        : this()
    {
        ImageId = Guard.Against.Default(imageId);
    }

    public Guid ImageId { get; private set; }
    public Guid ProductId { get; set; }
}
