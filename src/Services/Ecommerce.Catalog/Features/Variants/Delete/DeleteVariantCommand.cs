using Ecommerce.Catalog.Domain.VariantAggregate;
using Ecommerce.Catalog.Domain.VariantAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Variants.Delete;

internal sealed record DeleteVariantCommand(long Id) : ICommand;

internal sealed class DeleteVariantHandler(IRepository<Variant> repository)
    : ICommandHandler<DeleteVariantCommand>
{
    public async Task<Result> Handle(
        DeleteVariantCommand request,
        CancellationToken cancellationToken
    )
    {
        var variant = await repository.FirstOrDefaultAsync(
            new VariantFilterSpec(),
            cancellationToken
        );

        if (variant is null)
        {
            return Result.NotFound();
        }

        variant.Delete();

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
