using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups.Delete;

internal sealed record DeleteAttributeGroupCommand(long Id) : ICommand;

internal sealed class DeleteAttributeGroupHandler(IRepository<ProductAttributeGroup> repository)
    : ICommandHandler<DeleteAttributeGroupCommand>
{
    public async Task<Result> Handle(
        DeleteAttributeGroupCommand request,
        CancellationToken cancellationToken
    )
    {
        var attributeGroup = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (attributeGroup is null)
        {
            return Result.NotFound();
        }

        await repository.DeleteAsync(attributeGroup, cancellationToken);

        return Result.Success();
    }
}
