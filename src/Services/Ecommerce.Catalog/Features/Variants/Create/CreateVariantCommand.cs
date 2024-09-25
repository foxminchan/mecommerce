using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Features.Variants.Create;

internal sealed record CreateVariantCommand(string? Name, VariantType Type)
    : ICommand<Result<long>>;

internal sealed class CreateVariantHandler(IRepository<Variant> repository)
    : ICommandHandler<CreateVariantCommand, Result<long>>
{
    public async Task<Result<long>> Handle(
        CreateVariantCommand request,
        CancellationToken cancellationToken
    )
    {
        var variant = new Variant(request.Name, request.Type);

        var result = await repository.AddAsync(variant, cancellationToken);

        return result.Id;
    }
}
