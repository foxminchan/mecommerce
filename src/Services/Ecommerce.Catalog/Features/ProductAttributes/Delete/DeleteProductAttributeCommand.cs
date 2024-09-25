using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributes.Delete;

internal sealed record DeleteProductAttributeCommand(long Id) : ICommand;

internal sealed class DeleteProductAttributeHandler(IRepository<ProductAttribute> repository)
    : ICommandHandler<DeleteProductAttributeCommand>
{
    public async Task<Result> Handle(
        DeleteProductAttributeCommand request,
        CancellationToken cancellationToken
    )
    {
        var productAttribute = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, productAttribute);

        await repository.DeleteAsync(productAttribute, cancellationToken);

        return Result.Success();
    }
}
