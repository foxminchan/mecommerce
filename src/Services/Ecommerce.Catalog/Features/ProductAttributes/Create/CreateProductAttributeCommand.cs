using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributes.Create;

internal sealed record CreateProductAttributeCommand(string? Name, long? AttributeGroupId)
    : ICommand<Result<long>>;

internal sealed class CreateProductAttributeHandler(IRepository<ProductAttribute> repository)
    : ICommandHandler<CreateProductAttributeCommand, Result<long>>
{
    public async Task<Result<long>> Handle(
        CreateProductAttributeCommand request,
        CancellationToken cancellationToken
    )
    {
        var productAttribute = new ProductAttribute(request.Name, request.AttributeGroupId);

        var result = await repository.AddAsync(productAttribute, cancellationToken);

        return result.Id;
    }
}
