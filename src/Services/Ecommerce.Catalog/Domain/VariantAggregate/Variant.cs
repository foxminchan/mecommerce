namespace Ecommerce.Catalog.Domain.VariantAggregate;

public sealed class Variant : AuditableEntity<long>, IAggregateRoot, ISoftDelete
{
    private Variant() { }

    public Variant(string? name, VariantType type)
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
        Type = Guard.Against.EnumOutOfRange(type);
    }

    public string? Name { get; private set; }
    public VariantType Type { get; private set; }
    public bool IsDeleted { get; set; }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void Update(string? name, VariantType type)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Type = Guard.Against.EnumOutOfRange(type);
    }
}
