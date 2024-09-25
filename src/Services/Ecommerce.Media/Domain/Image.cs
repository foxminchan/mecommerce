namespace Ecommerce.Media.Domain;

public sealed class Image : AuditableEntity<Guid>, IAggregateRoot
{
    public Image() { }

    public Image(string? fileName, string? caption, MediaType type)
        : this()
    {
        FileName = Guard.Against.NullOrEmpty(fileName);
        Caption = Guard.Against.NullOrEmpty(caption);
        Type = Guard.Against.EnumOutOfRange(type);
    }

    public string? FileName { get; private set; }
    public string? Caption { get; private set; }
    public MediaType Type { get; private set; }
}
