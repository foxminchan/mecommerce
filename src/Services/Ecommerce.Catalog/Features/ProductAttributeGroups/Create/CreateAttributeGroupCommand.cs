using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups.Create;

internal sealed record CreateAttributeGroupCommand(string? Name) : ICommand<Result<long>>;

internal sealed class CreateAttributeGroupHandler(IRepository<ProductAttributeGroup> repository)
    : ICommandHandler<CreateAttributeGroupCommand, Result<long>>
{
    public async Task<Result<long>> Handle(
        CreateAttributeGroupCommand request,
        CancellationToken cancellationToken
    )
    {
        var attributeGroup = new ProductAttributeGroup(request.Name);

        var result = await repository.AddAsync(attributeGroup, cancellationToken);

        return result.Id;
    }
}
