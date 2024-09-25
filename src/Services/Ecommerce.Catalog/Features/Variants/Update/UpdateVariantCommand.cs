using Ecommerce.Catalog.Domain.VariantAggregate;
using Ecommerce.Catalog.Domain.VariantAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Variants.Update;

internal sealed record UpdateVariantCommand(long Id, string? Name, VariantType Type) : ICommand;

internal sealed class UpdateVariantHandler(IRepository<Variant> repository)
    : ICommandHandler<UpdateVariantCommand>
{
    public async Task<Result> Handle(
        UpdateVariantCommand request,
        CancellationToken cancellationToken
    )
    {
        var variant = await repository.GetByIdAsync(
            new VariantFilterSpec(request.Id),
            cancellationToken
        );

        if (variant is null)
        {
            return Result.NotFound();
        }

        variant.Update(request.Name, request.Type);

        await repository.UpdateAsync(variant, cancellationToken);

        return Result.Success();
    }
}
