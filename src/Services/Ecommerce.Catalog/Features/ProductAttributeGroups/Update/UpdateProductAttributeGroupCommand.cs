using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups.Update;

internal sealed record UpdateProductAttributeGroupCommand(long Id, string? Name) : ICommand;

internal sealed class UpdateProductAttributeGroupHandler(
    IRepository<ProductAttributeGroup> repository
) : ICommandHandler<UpdateProductAttributeGroupCommand>
{
    public async Task<Result> Handle(
        UpdateProductAttributeGroupCommand request,
        CancellationToken cancellationToken
    )
    {
        var attributeGroup = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (attributeGroup is null)
        {
            return Result.NotFound();
        }

        attributeGroup.UpdateName(request.Name);

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
