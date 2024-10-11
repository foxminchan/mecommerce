namespace Ecommerce.Catalog.Features.Products.Dtos;

public sealed record ProductAttributeCombinationDto(
    string? Value,
    long AttributeId,
    int DisplayOrder
);

internal sealed class ProductAttributeCombinationDtoValidator
    : AbstractValidator<ProductAttributeCombinationDto>
{
    public ProductAttributeCombinationDtoValidator()
    {
        RuleFor(x => x.Value).NotEmpty().MaximumLength(DataSchemaLength.Medium);

        RuleFor(x => x.AttributeId).NotEmpty();

        RuleFor(x => x.DisplayOrder).GreaterThan(0);
    }
}
