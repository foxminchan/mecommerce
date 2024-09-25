using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributes.Update;

internal sealed record UpdateProductAttributeCommand(long Id, string? Name, long? AttributeGroupId)
    : ICommand;

internal sealed class UpdateProductAttributeHandler(IRepository<ProductAttribute> repository)
    : ICommandHandler<UpdateProductAttributeCommand>
{
    public async Task<Result> Handle(
        UpdateProductAttributeCommand request,
        CancellationToken cancellationToken = default
    )
    {
        var productAttribute = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, productAttribute);

        productAttribute.UpdateInformation(request.Name, request.AttributeGroupId);

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
